using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments
{
    public class ShowBenefitPaymentsModelView
    {
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }
        public int BenefitId { get; set; }

    }
}
