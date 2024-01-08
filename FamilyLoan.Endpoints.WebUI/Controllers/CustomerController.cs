
using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Commands;
using FamilyLoan.Core.ApplicaionService.Customers.Commands.DeleteCustomers;
using FamilyLoan.Core.ApplicaionService.Customers.Commands.UpdateCustomers;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.CheckUserHasAccount;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetCustomerByID;
using FamilyLoan.Core.ApplicationServices.Customers.Queries.GetPagedCustomers;
using FamilyLoan.Endpoints.WebUI.VIewModels.Customers;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{

    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PageParameters _settings;



        public CustomerController(IMediator mediator, IMapper mapper, IOptions<PageParameters> settings)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = settings.Value;

        }
        [HttpGet]
        public IActionResult List(int pageNumber = 1, string search = "")
        {

            var result = _mediator.Send(new GetPagedCustomersQuery()
            {
                PageNumber = pageNumber,
                PageSize = _settings.PageSize,
                Search = search


            }).GetAwaiter().GetResult();

            return View(result);
        }


        #region add
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(CreateCustomerViewModel model)
        {

            if (ModelState.IsValid)
            {

                AddCustomerCommand command = _mapper.Map<AddCustomerCommand>(model);

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


        #region update
        [HttpGet]
        public IActionResult Update(int id)
        {
            GetCustomerByIDQuery query = new() { Id = id };
            var customerDTO = _mediator.Send(query).GetAwaiter().GetResult();
            UpdateCustomerViewModel model = _mapper.Map<UpdateCustomerViewModel>(customerDTO);
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(UpdateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {

                UpdateCustomerCommand command = _mapper.Map<UpdateCustomerCommand>(model);
                var updateResult = _mediator.Send(command).Result;
                if (updateResult.IsSuccess)
                {

                    return RedirectToAction(nameof(List));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, updateResult.Error);
                }
            }

            return View(model);

        }

        #endregion


        #region delete
        public IActionResult Delete(int id)
        {
            GetCustomerByIDQuery query = new() { Id = id };

            var customerDTO = _mediator.Send(query).GetAwaiter().GetResult();
            if (customerDTO != null)
            {

                DeleteCustomerViewModel model = _mapper.Map<DeleteCustomerViewModel>(customerDTO);
                var hasAccount = _mediator.Send(new CheckUserHasAccountOrLoanQuery()
                {
                    CustomerId = id
                }).GetAwaiter().GetResult();
                if (hasAccount)
                {
                    model.AllowDelete = false;
                    model.Message = " کاربر حساب یا وام حذف نشده دارد!!";
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
                DeleteCustomerCommand command = new()
                {
                    Id = id
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



        public IActionResult Details(int id)
        {
            GetCustomerByIDQuery query = new() { Id = id };
            var customerDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsCustomerViewModel model = _mapper.Map<DetailsCustomerViewModel>(customerDTO);


            return PartialView("_Details", model);


        }

    }
}

