using FamilyLoan.Core.Domains.Loans;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class AddInstallmentViewModel
    {
        public int LoanId { get; set; }

        [Display(Name = "مبلغ قسط")]
        public long InstallmentAmount { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تاریخ پرداخت قسط")]
        public string InstallmentDate { get; set; }
        public Loan Loan { get; set; }


    }
}
