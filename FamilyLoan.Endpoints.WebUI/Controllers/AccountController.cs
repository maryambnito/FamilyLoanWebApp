using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationService.Accounts.Command.DeleteAccounts;
using FamilyLoan.Core.ApplicationService.Accounts.Command.UpdateAccounts;
using FamilyLoan.Core.ApplicationService.Accounts.Query.GetAccountById;
using FamilyLoan.Core.ApplicationService.Accounts.Query.GetPagedAccounts;
using FamilyLoan.Core.ApplicationServices.Accounts.Query.CheckAccountHasPayment;
using FamilyLoan.Core.AppplicationService.Accounts.Command.AddAccounts;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Endpoints.WebUI.VIewModels.Accounts;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly PageParameters _settings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public AccountController(IMediator mediator, IMapper mapper
            , IOptions<PageParameters> settings)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = settings.Value;

        }

        [HttpGet]

        public IActionResult List(int PageNumber = 1, string search = "")
        {
            var result = _mediator.Send(new GetPagedAccountsQuery()
            {

                PageNumber = PageNumber,
                PageSize = _settings.PageSize,
                Search = search

            }).GetAwaiter().GetResult();

            return View(result);
        }
        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            var customerList = _mediator.Send(new GetAllCustomerQuery()).GetAwaiter().GetResult();
            CreateAccountGetViewModel viewModel = new();
            viewModel.CustomerForDisplay = customerList;
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Add(CreateAccountPostViewModel model)
        {
            if (ModelState.IsValid)
            {


                model.CreateAccountDate = model.CreateAccountDate.ChangeDateToEN();
                AddAccountCommand command = _mapper.Map<AddAccountCommand>(model);
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
        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            GetAccountByIdQuery query = new() { Id = id };
            var accountDTO = _mediator.Send(query).GetAwaiter().GetResult();
            UpdateAccountViewModel model = _mapper.Map<UpdateAccountViewModel>(accountDTO);
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(UpdateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var date = MapToEnglishNumber.PersianMap(model.CreateAccountDate);
                PersianDateTime dateTime = date.ToPersianDateTime();
                model.CreateAccountDate = Convert.ToString(dateTime.ToDateTime());
                UpdateAccountCommand command = _mapper.Map<UpdateAccountCommand>(model);
                _mediator.Send(command);
                return RedirectToAction(nameof(List));
            }

            return View(model);

        }
        #endregion
        #region Delete
        [HttpGet]
        public IActionResult DeleteAccountById(int id)
        {
            var result = _mediator.Send(new GetAccountByIdQuery() { Id = id }).GetAwaiter().GetResult();
            DeleteAccountViewModel model = _mapper.Map<DeleteAccountViewModel>(result);
            var hasAccount = _mediator.Send(new CheckAccountHasPaymentQuery()
            {
                AccountId = id
            }).GetAwaiter().GetResult();
            if (hasAccount)
            {
                model.AllowDelete = false;
                model.Message = " لطفا اول تراکنش های حساب را حذف کنید";
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
                DeleteAccountCommand command = new()
                {
                    Id = id,

                };
                _mediator.Send(command);

                return RedirectToAction(nameof(List));
            }
            else
            {

                return NotFound("حسابی با این مشخصات وجود ندارد");
            }



        }


        #endregion


        public IActionResult Details(int id)
        {
            GetAccountByIdQuery query = new() { Id = id };
            var AccountDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsAccountViewModel model = _mapper.Map<DetailsAccountViewModel>(AccountDTO);
            return PartialView("_Details", model);
        }


    }
}
