using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{
    public class CreateCustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Required]

        [Display(Name = "نام")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "شماره کارت")]
        public string CardNo { get; set; }
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "نام کاربری")]
        [Required]
        public string Username { get; set; }
        [Required]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
       
        [Display(Name = "تایید کلمه عبور")]
        [Compare("Password",ErrorMessage = "پسورد یکسان نیست")]
        public string Passwordconfirm { get; set; }


    }
    }