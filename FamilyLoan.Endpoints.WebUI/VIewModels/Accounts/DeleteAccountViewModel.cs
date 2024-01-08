using FamilyLoan.Core.Domain.Customers;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Accounts
{
    public class DeleteAccountViewModel
    {

        public int Id { get; set; }
        [Display(Name = "شماره حساب")]
        public string AccountNO { get; set; }
        [Display(Name = "مشتری")]
        public Customer customer { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "هشدار")]
        public string Message { get; set; }
        public bool AllowDelete { get; set; } = true;
    }

}

