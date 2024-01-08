using FamilyLoan.Core.Domains.Loans;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Reports
{
    public class ShowLoanReportViewModel
    {

        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }
        public LoanState LoanState { get; set; }
        public int CustomerId { get; set; }
    }
}
