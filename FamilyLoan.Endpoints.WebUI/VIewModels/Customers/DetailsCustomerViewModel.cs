using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{
    public class DetailsCustomerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "شماره کارت")]
        public string CardNo { get; set; }
        [Display(Name = "نام کاربری")]

        public string Username { get; set; }
      

    }
}
