using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationService.Accounts.Query.GetAllAccounts;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetAllLoan;
using FamilyLoan.Endpoints.WebUI.VIewModels.Home;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FamilyLoan.Endpoints.WebUI.Controllers
{

    public class HomeController : BaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {

            int Customers = _mediator.Send(new GetAllCustomerQuery()).GetAwaiter().GetResult().Count;
            int Accounts = _mediator.Send(new GetAllAccountQuery()).GetAwaiter().GetResult().Count;
            int Loans = _mediator.Send(new GetAllLoanQuery()).GetAwaiter().GetResult().Count;
            HomeViewModel models = new()
            {
                AccountCount = Accounts,
                CustomerCount = Customers,
                LoanCount = Loans,
                DateTime = DateTime.Now
            };
            return View(models);
        }
        [Route("/error")]
        public IActionResult Error()
        {

            return View();
        }
    }
}
