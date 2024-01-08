using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class ShowInstallmentViewModel
    {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "از تاریخ")]
        public string FromDateLoan { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDateLoan { get; set; }
    }
}
