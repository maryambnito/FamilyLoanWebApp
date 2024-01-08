using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.loans.AddLLoans;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.loans.DeleteLoans;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.loans.UpdateLoans;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.CheckLoanHasInstallments;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetLoanByID;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetPagedLoans;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Endpoints.WebUI.VIewModels.Loans;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{

    public class LoanController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PageParameters _settings;


        public LoanController(IMediator mediator, IMapper mapper, IOptions<PageParameters> settings)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = settings.Value;
        }
        [HttpGet]
        public IActionResult List(int pageNumber = 1, string search = "")
        {
            var result = _mediator.Send(new GetPageLoanQuery()
            {
                PageNumber = pageNumber,
                PageSize = _settings.PageSize,
                Search = search


            }).GetAwaiter().GetResult();

            return View(result);
        }



        #region AddLoan
        [HttpGet]
        public IActionResult Add()
        {
            var CustomerList = _mediator.Send(new GetAllCustomerQuery()).GetAwaiter().GetResult();
            var ViewModel = new CreateLoanVIewModel();
            ViewModel.CustomerForDisplay = CustomerList;
            return View(ViewModel);
        }
        [HttpPost]
        public IActionResult Add(CreateLoanVIewModel model)
        {
            if (ModelState.IsValid)
            {

                model.LoanDateStart = model.LoanDateStart.ChangeDateToEN();
                AddLoanCommand command = _mapper.Map<AddLoanCommand>(model);

                _mediator.Send(command);

                return RedirectToAction(nameof(List));
            }

            return View();
        }
        #endregion


        #region UpdateLoan
        public IActionResult Update(int id)
        {
            GetLoanByIdQuery query = new() { LoanId = id };
            var Loan = _mediator.Send(query).GetAwaiter().GetResult();
            UpdateLoanViewModel model = _mapper.Map<UpdateLoanViewModel>(Loan);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateLoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var date = MapToEnglishNumber.PersianMap(model.LoanDateStart);
                PersianDateTime datetime = date.ToPersianDateTime();
                model.LoanDateStart = Convert.ToString(datetime.ToDateTime());
                UpdateLoanCommand command = _mapper.Map<UpdateLoanCommand>(model);
                _mediator.Send(command);
                return RedirectToAction(nameof(List));

            }
            return View();
        }
        #endregion


        #region Delete
        [HttpGet]
        public IActionResult DeleteLoanById(int id)
        {
            var result = _mediator.Send(new GetLoanByIdQuery() { LoanId = id }).GetAwaiter().GetResult();
            DeleteLoanVIewModel model = _mapper.Map<DeleteLoanVIewModel>(result);
            var hasAccount = _mediator.Send(new CheckLoanHasInstallmentsQuery()
            {
                LoanId = id
            }).GetAwaiter().GetResult();
            if (hasAccount)
            {
                model.AllowDelete = false;
                model.Message = " لطفا اول اقساط وام را حذف کنید";
            }


            ViewBag.m1 = "m1";
            TempData["m2"] = "m2";


            return PartialView("_Delete", model);


        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                DeleteLoanCommand command = new()
                {
                    LoanId = id,

                };
                _mediator.Send(command);

                return RedirectToAction(nameof(List));
            }
            else
            {

                return NotFound("وامی با این مشخصات وجود ندارد");
            }




        }


        #endregion






        public IActionResult Details(int id)
        {
            GetLoanByIdQuery query = new() { LoanId = id };
            var LoanDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsLoanVIewModel model = _mapper.Map<DetailsLoanVIewModel>(LoanDTO);

            return PartialView("_Details", model);
        }
    }
}
