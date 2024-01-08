using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Benefits.Command.AddBenefits;
using FamilyLoan.Core.ApplicationServices.Benefits.Command.DeleteBenefits;
using FamilyLoan.Core.ApplicationServices.Benefits.Command.UpdateBenefits;
using FamilyLoan.Core.ApplicationServices.Benefits.Query.CheckBenefitHasPayments;
using FamilyLoan.Core.ApplicationServices.Benefits.Query.GetAllBenefits;
using FamilyLoan.Core.ApplicationServices.Benefits.Query.GetBenefitById;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.AddPayments;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.DeletePayments;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsByBenefitId;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsById;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetTotalPayments;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Endpoints.WebUI.VIewModels.Benefits;
using FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments;
using FamilyLoan.Endpoints.WebUI.VIewModels.Payments;
using FamilyLoan.Utilities.ExtensionMethods;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{

    public class BenefitController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PageParameters _settings;

        public BenefitController(IMediator mediator, IMapper mapper, IOptions<PageParameters> settings)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = settings.Value;
        }
        public IActionResult List()
        {
            var result = _mediator.Send(new GetBenefitQuery()).GetAwaiter().GetResult();

            return View(result);

        }
        #region delete mainbenefit
        public IActionResult Delete(int id)
        {
            GetBenefitByIdQuery query = new() { BenefitId = id };

            var BenefitDTO = _mediator.Send(query).GetAwaiter().GetResult();
            if (BenefitDTO != null)
            {

                DeleteBenefitViewModel model = _mapper.Map<DeleteBenefitViewModel>(BenefitDTO);
                var hasAccount = _mediator.Send(new CheckBenefitHasPaymentsQuery()
                {
                    Payments = BenefitDTO.Payments,
                    BenefitId = id
                }).GetAwaiter().GetResult();
                if (hasAccount)
                {
                    model.AllowDelete = false;
                    model.Message = " لطفا اول تراکنش های حساب را حذف کنید";
                }

                return View(model);
            }
            ViewBag.m1 = "m1";
            TempData["m2"] = "m2";

            return RedirectToAction(nameof(List));
        }

        public IActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                DeleteBenefitCommand command = new()
                {
                    BenefitId = id
                };
                _mediator.Send(command);
                return RedirectToAction(nameof(List));

            }
            else
            {
                return NotFound();

            }

        }

        #endregion
        #region add mainbenefit
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(AddBenefitsViewModel model)
        {
            if (ModelState.IsValid)
            {


                AddBenefitCommand command = _mapper.Map<AddBenefitCommand>(model);

                var addResult = _mediator.Send(command).Result;
                if (addResult.IsSuccess)
                {

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, addResult.Error);
                }
            }

            return View(model);

        }
        #endregion
        #region update mainbenefit
        [HttpGet]
        public IActionResult Update(UpdateBenefitsViewModel model)
        {
            return PartialView("_UpdateBenefit", model);
        }

        [HttpPost]
        public IActionResult UpdateDescription(UpdateBenefitsViewModel model)
        {

            if (ModelState.IsValid)
            {

                UpdateBenefitCommand command = _mapper.Map<UpdateBenefitCommand>(model);

                var updateResult = _mediator.Send(command).Result;
                if (updateResult.IsSuccess)
                {
                    return JsonSuccess();

                }
                else
                {
                    return JsonFail();
                }


            }
            return Json("model valid nis!");


        }
        #endregion

        #region BENEFIT PAYMENTS

        public IActionResult BenefitTransaction()
        {
            var benefitResult = _mediator.Send(new GetBenefitQuery())
                 .GetAwaiter().GetResult();
            CreatePaymentBenefitViewModel BenefitViewModel = new();
            BenefitViewModel.BenefitDTO = benefitResult;
            BenefitViewModel.BenefitId = benefitResult.Id;
            return View(BenefitViewModel);

        }

        public IActionResult TotalAmount(ShowBenefitPaymentsModelView model)
        {
            var sepResult = "";
            model.FromDate = model.FromDate.ChangeDateToEN();
            model.ToDate = model.ToDate.ChangeDateToEN();
            GetTotalPaymentsQuery query = _mapper.Map<GetTotalPaymentsQuery>(model);


            var result = _mediator.Send(query).GetAwaiter().GetResult();
            if (result != 0)
            {
                sepResult = result.Value.SeparatorNum();

            }

            return Json(sepResult);
        }

        [HttpPost]
        public IActionResult BenefitList(ShowBenefitPaymentsModelView model)
        {
            model.FromDate = model.FromDate.ChangeDateToEN();
            model.ToDate = model.ToDate.ChangeDateToEN();

            GetPaymentsByBenefitIdQuery query = _mapper.Map<GetPaymentsByBenefitIdQuery>(model);


            var PaymentDTO = _mediator.Send(query).GetAwaiter().GetResult();

            return PartialView("_PaymentBenefitList", PaymentDTO);
        }

        #region AddbenefitPayment


        [HttpGet]
        public IActionResult AddPaymentByBenefitId(int id)
        {

            AddPaymentBenefitViewModel model = new()
            {
                BenefitId = id
            };
            return PartialView("_AddPaymentBenefit", model);
        }


        [HttpPost]
        public IActionResult AddPaymentByBenefit(AddPaymentBenefitViewModel model)
        {
            if (ModelState.IsValid)
            {

                model.PaymentDate = model.PaymentDate.ChangeDateToEN();
                model.PaymentType = PaymentType.Benefit;
                AddPaymentCommand command = _mapper.Map<AddPaymentCommand>(model);
                var addResult = _mediator.Send(command).Result;
                if (addResult.IsSuccess)
                {
                    return JsonSuccess();

                }
                else
                {
                    return JsonFail();
                }


            }
            return Json("model valid nis!");

        }
        #endregion



        #region DeleteBenefitPayment


        [HttpPost]
        public IActionResult DeleteBenefitPeyment(int id)
        {

            DeletePaymentCommand command = new()
            {
                Id = id

            };
            _mediator.Send(command);

            return JsonSuccess();
        }
        #endregion


        [HttpGet]
        public IActionResult DetailsBenefit(int Id)
        {
            GetPaymentByIdQuery query = new() { Id = Id };
            var paymentDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsPaymentBenefitViewModel model = _mapper.Map<DetailsPaymentBenefitViewModel>(paymentDTO);
            return PartialView("_DetailsPaymentBenefit", model);
        }

        #endregion
    }
}