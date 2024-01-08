using FamilyLoan.Core.Domain.Accounts.DTO;
using FamilyLoan.Core.Domain.Customers.DTOs;
using FamilyLoan.Core.Domains.Loans.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Payments
{
    public class CreatePaymentViewModel
    {

        [Display(Name = "لیست حساب ها ")]
        public int AccountId { get; set; }
        public List<AccountListItemDTO> AccountList { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
       
        public int CustomerId { get; set; }
        [Display(Name = "لیست مشتری ها ")]
        public List<CustomerDTO> CustomerList { get; set; }





        [Display(Name = "لیست وام ها ")]
        public long LoanId { get; set; }
        public List<LoanDTO> LoanList { get; set; }
        public string FromDateLoan { get; set; }
        public string ToDateLoan { get; set; }


    }
}
