using FamilyLoan.Core.Contracts.Payments;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;
using FamilyLoan.Core.Domains.Payments;
using System;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Payments
{
    public class DapperPaymentQueryRepository : ICalcutingPaymentQueryRepository
    {
        private readonly string connectionstring;
        public DapperPaymentQueryRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("FamilyLoanQuery");
        }

        public long? GetAllAccountsPayment()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var spName = "[dbo].[spPayment_totalAccounts]";
                var result = connection.QueryFirst<long?>(spName,commandType: System.Data.CommandType.StoredProcedure);
                if (result == 0)
                {
                    return 0;
                }
                return result;
            }

        }

        public long? GetTotalAccounts(int accountId,PaymentType paymenttype)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                
                AccountSPInput obj = new() { AccountId = accountId ,PaymentType=paymenttype};
                var spName = "[dbo].[spPayments_totalAmount]";
                var result = connection.QueryFirst<long?>(spName,obj,commandType:System.Data.CommandType.StoredProcedure);
                if (result == 0)
                {
                    return 0;
                }
                return result;
            }

        }
        public long? GetTotalBenefits(int benefitId)
        {
            BenefitSPInput obj = new() { BenefitId = benefitId };
            using (var connection = new SqlConnection(connectionstring))
            {
                var spName = "[dbo].[spPayments_totalBenefit]";
                var result = connection.QueryFirst<long?>(spName, obj, commandType:System.Data.CommandType.StoredProcedure);
                if (result == 0)
                {
                    return 0;
                }
                return result;
            }

        }

        
    }
}
