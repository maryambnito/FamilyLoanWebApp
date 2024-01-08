using FamilyLoan.Core.Domain.Customers.DTOs;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Utilities.ExtensionMethods;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Reports
{
    public class LoansListsViewModel
    {
        public LoansListsViewModel()
        {
            LoanStates = Loanstate.ToDictionary();
        }

        public int Id { get; set; }
        public LoanState Loanstate { get; set; }
        public long TotalLoanAmount { get; set; }
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }
        public Dictionary<LoanState,string>  LoanStates { get; set; }
        public int CustomerId { get; set; }
        public List<CustomerDTO> CustomerList { get; set; }

    }
}
