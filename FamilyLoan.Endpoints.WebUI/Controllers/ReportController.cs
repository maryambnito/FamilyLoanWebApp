using AutoMapper;
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationServices.Accounts.Query.GetAllAccountsList;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetAllLoansState;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetTotalLoansAmount.GetTotalLoansAmounts;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetAllAccountsPayment;
using FamilyLoan.Core.ApplicationServices.Reports;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Common;
using FamilyLoan.Endpoints.WebUI.VIewModels.Reports;
using FamilyLoan.Utilities.ExtensionMethods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{
    
    public class ReportController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReportController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region AccountsLists
        [HttpGet]
        public IActionResult AccountsLists(string search = "")
        {
            var result = _mediator.Send(new GetAllAccountsListQuery()
            {
                Search = search
            }).GetAwaiter().GetResult();
            return View(result);
        }


        public IActionResult TotalAmount()
        {
            string sepResult = "0";
            long? result = _mediator.Send(new GetAllAccountsPaymentQuery()).GetAwaiter().GetResult();
            if (result != 0)
            {

                sepResult = result.Value.SeparatorNum();
            }

            return Json(sepResult);
        }


        #endregion
        #region LoansLists
        public IActionResult LoansLists()
        {
            var CustomerList = _mediator.Send(new GetAllCustomerQuery())
            .GetAwaiter().GetResult();
            LoansListsViewModel model = new();
            model.CustomerList = CustomerList;
            return View(model);


        }

        public IActionResult TotalLoansAmount(LoanState loanState)
        {
            var sepResult = "0";
            var result = _mediator.Send(new GetTotalLoansAmountQuery() { LoanState = loanState })
                .GetAwaiter().GetResult();
            if (result != null)
            {

                sepResult = result.Value.SeparatorNum();
            }
            return Json(sepResult);
        }




        [HttpPost]
        public IActionResult LoanListFilter(ShowLoanReportViewModel model)
        {
            if (model.FromDate != null || model.ToDate != null)
            {

                model.FromDate = model.FromDate.ChangeDateToEN();
                model.ToDate = model.ToDate.ChangeDateToEN();
            }

            GetAllLoanByStateQuery query = _mapper.Map<GetAllLoanByStateQuery>(model);
            var result = _mediator.Send(query).GetAwaiter().GetResult();


            return PartialView("_LoanList", result);
        }





        #endregion
        #region LoansAndAccountLists

        public IActionResult LoansAndAccountsList()
        {
            var moeinKolReportDTOs = _mediator
                .Send(new GetAllAccountsAndLoansQuery()).GetAwaiter().GetResult();

            return View(moeinKolReportDTOs);
        }
        #endregion

        public IActionResult DaftarKol()
        {
            var moeinKolDTO = _mediator.Send(new GettorinKolQuery()).GetAwaiter().GetResult();
            return View(moeinKolDTO);
        }
    }
}
