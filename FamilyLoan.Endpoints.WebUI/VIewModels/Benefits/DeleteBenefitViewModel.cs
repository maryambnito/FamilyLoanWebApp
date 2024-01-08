using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits
{
    public class DeleteBenefitViewModel
    {
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Dexcription { get; set; }
        public bool AllowDelete { get; set; } = true;
        [Display(Name = "هشدار")]

        public string Message { get; set; }
    }
}
