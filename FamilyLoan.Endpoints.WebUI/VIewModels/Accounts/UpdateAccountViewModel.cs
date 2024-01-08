using FamilyLoan.Core.Domain.Customers;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Accounts
{
    public class UpdateAccountViewModel
    {
        public int Id { get; set; }

        
        [Display(Name = "تاریخ")]
        public string CreateAccountDate { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "نام مشتری")]
        public int CustomerId { get; set; }
        [Display(Name = "شماره حساب")]
        public string AccountNO { get; set; }
        [Display(Name = "مشتری")]

        public Customer customer { get; set; }


    }
}
