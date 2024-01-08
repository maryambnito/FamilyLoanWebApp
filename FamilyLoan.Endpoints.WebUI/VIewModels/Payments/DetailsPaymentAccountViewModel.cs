using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class DetailsPaymentAccountViewModel
    {
        public int Id { get; set; }


        [Display(Name = "توضیحات")]
        public string Description { get; set; }

    }
}
