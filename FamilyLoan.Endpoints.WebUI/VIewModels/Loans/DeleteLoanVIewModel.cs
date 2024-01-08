using FamilyLoan.Core.Domain.Customers;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Loans
{
    public class DeleteLoanVIewModel
    {
        public int Id { get; set; }
        [Display(Name = "مبلغ وام")]
        public int LoanAmount { get; set; }

        [Display(Name = "مشتری")]

        public Customer Customer { get; set; }
        [Display(Name ="هشدار")]
        public string Message { get; set; }
        public bool AllowDelete { get; set; } = true;
        public int CustomerId { get; set; }
    }
}
