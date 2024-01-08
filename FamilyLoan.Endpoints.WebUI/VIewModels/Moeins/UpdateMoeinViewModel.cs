using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Moeins
{
    public class UpdateMoeinViewModel
    {
        public int Id { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }
        [Display(Name = "بدهکار")]
        public long? Debtor { get; set; }
        [Display(Name = "بستانکار")]
        public long? Creditor { get; set; }
        [Display(Name = "جمع")]
        public long? Sum { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}
