using FamilyLoan.Core.Domain.Customers.DTOs;
using System.Collections.Generic;

namespace FamilyLoan.Endpoints.WebUI.VIewModels.Reports
{
    public class LoansAndAccountsListViewModel
    {
        public int CustomerId{ get; set; }
        public List<CustomerDTO> s{ get; set; }
    }
}
