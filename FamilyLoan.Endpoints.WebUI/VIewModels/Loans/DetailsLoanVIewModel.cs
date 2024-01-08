using FamilyLoan.Core.Domains.Loans;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Loans
{
    public class DetailsLoanVIewModel
    {
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name ="وضعبت")]
        public LoanState LoanState { get; set; }

    }
}
