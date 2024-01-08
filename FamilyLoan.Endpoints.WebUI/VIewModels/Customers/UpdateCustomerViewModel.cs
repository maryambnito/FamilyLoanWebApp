using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{
    public class UpdateCustomerViewModel
    {



        public int Id{ get; set; }
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "شماره کارت")]
        public string CardNo { get; set; }
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }
       

        
    }
}
