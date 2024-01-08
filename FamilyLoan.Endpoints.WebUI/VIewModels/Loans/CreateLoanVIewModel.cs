using FamilyLoan.Core.Domain.Customers.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Loans
{
    public class CreateLoanVIewModel
    {


        [Display(Name = "لیست مشتری ها ")]
        public List<CustomerDTO> CustomerForDisplay { get; set; }
        [Display(Name = "نام مشتری")]
        public int CustomerId { get; set; }
        [Display(Name = "مبلغ وام")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public int LoanAmount { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "تاریخ وام")]
        public string LoanDateStart { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


    }
}
