using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Accounts
{
    public class DetailsAccountViewModel
    {
        public int Id{ get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
