using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Home
{
    public class HomeViewModel
    {

        [Display(Name = "تعداد مشتری ها")]
        public int CustomerCount { get; set; }
        [Display(Name = "تعداد حساب ها")]
        public int AccountCount { get; set; }
        [Display(Name = "تعداد وام ها")]
        public int LoanCount{ get; set; }
        public DateTime DateTime { get; set; }
    }

}
