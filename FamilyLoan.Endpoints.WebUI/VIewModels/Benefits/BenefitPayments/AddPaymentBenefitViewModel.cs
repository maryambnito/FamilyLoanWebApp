using FamilyLoan.Core.Domains.Payments;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments
{
    public class AddPaymentBenefitViewModel
    {

        public int BenefitId{ get; set; }
        [Display(Name = "مبلغ تراکنش")]
        public long PaymentAmount { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تاریخ تراکنش")]
        public string PaymentDate { get; set; }
        [Display(Name = "جمع تراکنش ها")]
        public long TotalAmount { get; set; }
        public PaymentType  PaymentType{ get; set; }
    }
}
