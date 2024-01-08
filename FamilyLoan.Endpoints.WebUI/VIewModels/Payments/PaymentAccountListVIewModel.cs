using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class PaymentAccountListVIewModel
    {
        public int Id{ get; set; }

        public int AccountId { get; set; }

        [Display(Name = "تاریخ تراکنش")]
        public string PaymentDate { get; set; }

        [Display(Name = "مبلغ تراکنش")]
        public long PaymentAmount { get; set; }

        [Display(Name ="توضیحات")]
        public string Description{ get; set; }

        [Display(Name ="جمع موجودی")]
        public long TotalAmount{ get; set; }

 
       
        
    }
}
