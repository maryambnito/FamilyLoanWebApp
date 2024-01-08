using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Customers
{
    public class DeleteCustomerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Display(Name ="هشدار")]
        public string Message{ get; set; }
        public IFormFile ProfileImage { get; set; }
        public bool AllowDelete { get; set; } = true;
    }
}
