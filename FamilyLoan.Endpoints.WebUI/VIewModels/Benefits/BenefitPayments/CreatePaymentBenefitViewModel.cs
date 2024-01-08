using FamilyLoan.Core.Domains.Benefits.DTO;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments

{
    public class CreatePaymentBenefitViewModel
    {
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }
        [Display(Name = "لیست حساب سود")]
        public int BenefitId { get; set; }
        [Display(Name = " حساب واریز سودها ")]
        public BenefitDTO BenefitDTO { get; set; }
        //public List<BenefitDTO> BenefitList { get; set; }
        [Display(Name = "مبلغ تراکنش")]
        public long PaymentAmount { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "تاریخ تراکنش")]
        public string PaymentDate { get; set; }
    }
}
