using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments
{
    public class DetailsPaymentBenefitViewModel
    {
        public int Id { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
