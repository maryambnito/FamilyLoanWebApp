using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationServices.Accounts.Query.GetAllAccountsByCustomerId;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.Installments.AddInstallments;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.Installments.DeleteInstallments;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.Installments.GetInstallmentByID;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.Installments.GetInstallmentByLoanId;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.Installments.SumInstallmentByLoanId;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetAllLoanByCustomerId;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetTotalLoansAmount.GetRemainingLoanById;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.AddPayments;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.DeletePayments;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsByAccountId;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsById;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetTotalPayments;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Endpoints.WebUI.VIewModels.Payments;
using FamilyLoan.Utilities.ExtensionMethods;
using FamilyLoan.Utilities.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace FamilyLoan.Endpoints.WebUI.Controllers
{

    public class PaymentController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly PageParameters _settings;



        public PaymentController(IMediator mediator, IMapper mapper, IOptions<PageParameters> settings)
        {
            _mediator = mediator;
            _mapper = mapper;
            _settings = settings.Value;


        }
        public IActionResult Transaction()
        {
            var CustomerList = _mediator.Send(new GetAllCustomerQuery())
              .GetAwaiter().GetResult();
            CreatePaymentViewModel CustomerViewModel = new();
            CustomerViewModel.CustomerList = CustomerList;

            return View(CustomerViewModel);
        }



        #region LoanTransaction
        #region LoanList
        public IActionResult LoanList(int Id)
        {
            var loanList = _mediator.Send(new GetAllLoanByCustomerIdQuery()
            {
                CustomerId = Id

            }).GetAwaiter().GetResult();

            return Json(loanList);
        }
        [HttpPost]
        public IActionResult InstallmentList(ShowInstallmentViewModel model)
        {
            model.FromDateLoan = model.FromDateLoan.ChangeDateToEN();
            model.ToDateLoan = model.ToDateLoan.ChangeDateToEN();
            GetInstallmentByLoanIdQuery query = _mapper.Map<GetInstallmentByLoanIdQuery>(model);
            var InstallmentDTO = _mediator.Send(query).GetAwaiter().GetResult();
            return PartialView("_InstallmentList", InstallmentDTO);
        }

        #endregion

        #region add Installment

        [HttpGet]
        public IActionResult AddInstallmentByLoanId(int Id)
        {
            AddInstallmentViewModel model = new()
            {
                LoanId = Id
            };
            return PartialView("_AddInstallment", model);
        }
        [HttpPost]
        public IActionResult AddInstallment(AddInstallmentViewModel model)
        {
            if (ModelState.IsValid)
            {

                model.InstallmentDate = model.InstallmentDate.ChangeDateToEN();
                AddInstallmentCommand command = _mapper.Map<AddInstallmentCommand>(model);

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
        #region totalInstallment
        public IActionResult TotalLoan(ShowInstallmentViewModel model)
        {
            string sepResult = "0";
            model.FromDateLoan = model.FromDateLoan.ChangeDateToEN();
            model.ToDateLoan = model.ToDateLoan.ChangeDateToEN();
            GetTotalLoanAmountQuery query = _mapper.Map<GetTotalLoanAmountQuery>(model);
            var result = _mediator.Send(query).GetAwaiter().GetResult();
            if (result != null)
            {
                sepResult = result.Value.SeparatorNum();

            }
            return Json(sepResult);
        }
        public IActionResult TotalInstallment(ShowInstallmentViewModel model)
        {
            string sepResult = "0";

            model.FromDateLoan = model.FromDateLoan.ChangeDateToEN();
            model.ToDateLoan = model.ToDateLoan.ChangeDateToEN();
            GetSumInstallmentByLoanIdQuery query = _mapper.Map<GetSumInstallmentByLoanIdQuery>(model);
            var result = _mediator.Send(query).GetAwaiter().GetResult();
            if (result != null)
            {
                sepResult = result.Value.SeparatorNum();
            }
            return Json(sepResult);
        }
        #endregion

        #region DeleteInstallment
        [HttpPost]
        public IActionResult DeleteInstallment(int id)
        {

            DeleteInstallmentCommand command = new()
            {
                InstallmentId = id,

            };
            var result = _mediator.Send(command).Result;
            if (result.IsSuccess)
            {
                return JsonSuccess();

            }




            return JsonFail();


        }
        #endregion

        public IActionResult DetailsInstallment(int id)
        {
            GetInstallmentByIdQuery query = new() { InstallmentId = id };
            var InstallmentDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsPaymentAccountViewModel model = _mapper.Map<DetailsPaymentAccountViewModel>(InstallmentDTO);
            return PartialView("_DetailsInstallment", model);
        }

        #endregion

        #region AccountTransaction

        #region AccountList
        public IActionResult AccountList(int Id)
        {
            var accountList = _mediator.Send(new GetAllAccountByCustomerIdQuery()
            {

                Id = Id

            }).GetAwaiter().GetResult();



            return Json(accountList);
        }

        public IActionResult TotalAmount(ShowPaymentsViewModel model)
        {
            var sepResult = "";
            model.FromDate = model.FromDate.ChangeDateToEN();
            model.ToDate = model.ToDate.ChangeDateToEN();

            GetTotalPaymentsQuery query = _mapper.Map<GetTotalPaymentsQuery>(model);
            query.PaymentType = PaymentType.Account;
            var result = _mediator.Send(query).GetAwaiter().GetResult();


            if (result != 0)
            {

                sepResult = result.Value.SeparatorNum();
            }
            return Json(sepResult);
        }
        [HttpPost]
        public IActionResult PaymentAccountList(ShowPaymentsViewModel model)
        {
            model.FromDate = model.FromDate.ChangeDateToEN();
            model.ToDate = model.ToDate.ChangeDateToEN();

            GetPaymentByAccountIdQuery query = _mapper.Map<GetPaymentByAccountIdQuery>(model);
            var PaymentDTO = _mediator.Send(query).GetAwaiter().GetResult();


            return PartialView("_PaymentAccountList", PaymentDTO);
        }

        #endregion



        #region AddAccount

        [HttpGet]
        public IActionResult AddPaymentByAccountId(int id)
        {

            AddPaymentViewModel model = new()
            {
                AccountId = id
            };
            return PartialView("_AddPaymentAccount", model);
        }


        [HttpPost]
        public IActionResult AddPaymentAccount(AddPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {

                model.PaymentDate = model.PaymentDate.ChangeDateToEN();

                model.PaymentType = PaymentType.Account;

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


        #region DeleteAnAccount


        [HttpPost]
        public IActionResult DeleteAccountPeyment(int id)
        {

            DeletePaymentCommand command = new()
            {
                Id = id,

            };
            var result = _mediator.Send(command).Result;
            if (result.IsSuccess)
            {
                return JsonSuccess();

            }




            return JsonFail();


        }
        #endregion
        public IActionResult DetailsAccountPeyment(int id)
        {
            GetPaymentByIdQuery query = new() { Id = id };
            var paymentDTO = _mediator.Send(query).GetAwaiter().GetResult();
            DetailsPaymentAccountViewModel model = _mapper.Map<DetailsPaymentAccountViewModel>(paymentDTO);
            return PartialView("_DetailsPayment", model);
        }



        #endregion

    }

}