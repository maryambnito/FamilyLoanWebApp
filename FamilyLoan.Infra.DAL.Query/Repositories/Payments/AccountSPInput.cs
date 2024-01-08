using FamilyLoan.Core.Domains.Payments;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Payments
{
    public class AccountSPInput
    {
        public PaymentType  PaymentType{ get; set; }
        public int AccountId{ get; set; }
    }
}
