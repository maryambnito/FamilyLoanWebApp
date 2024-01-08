using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class ShowPaymentsViewModel
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name ="تا تاریخ")]
        public string ToDate { get; set; }
    }
}
