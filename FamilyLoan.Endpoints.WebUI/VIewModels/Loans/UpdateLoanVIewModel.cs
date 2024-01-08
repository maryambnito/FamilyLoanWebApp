using FamilyLoan.Core.Domains.Loans;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Loans
{
    public class UpdateLoanViewModel
    {
        public int Id { get; set; }
       
        public List<Installment> Installments { get; set; }
        [Display(Name = "تاریخ وام")]
        public string LoanDateStart { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "مبلغ وام")]
        public long LoanAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
