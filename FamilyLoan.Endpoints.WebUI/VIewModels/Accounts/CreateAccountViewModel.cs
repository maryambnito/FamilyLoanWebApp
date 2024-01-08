using FamilyLoan.Core.Domain.Customers.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Accounts
{
    public abstract class CreateAccountViewModel
    {
      
        [Display(Name = "تاریخ")]
        public string CreateAccountDate { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "شماره حساب")]
        public string AccountNO { get; set; }
        [Display(Name = "نام مشتری")]
        public int CustomerId { get; set; }

    }
    public class CreateAccountGetViewModel : CreateAccountViewModel
    {
        [Display(Name = "لیست مشتری ها ")]

        public List<CustomerDTO> CustomerForDisplay { get; set; }

    }
    public class CreateAccountPostViewModel : CreateAccountViewModel
    {


    }

}
