using Dapper;
using FamilyLoan.Core.Contracts.Loans;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Loans.LoanSp
{
    public class DapperAllLoansQueryRepository : ICalcutingAllLoansQueryRepository
    {
        private readonly string connectionstring;
        public DapperAllLoansQueryRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("FamilyLoanQuery");
        }

        public long? GetSumAllLoans()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                
                var spName = "[dbo].[spTotalSAllLoansAmount]";
                var result = connection.QueryFirst<long?>(spName, commandType: System.Data.CommandType.StoredProcedure);
                if (result == 0)
                {
                    return 0;
                }
                return result;
            }
        }

        public long? GetSumAllLoansByState(int loanState)
        {

            using (var connection = new SqlConnection(connectionstring))
            {
                LoanSpInput obj = new() { LoanState= loanState};
                var spName = "[dbo].[spTotalLoansAmount]";
                var result = connection.QueryFirst<long?>(spName,obj, commandType: System.Data.CommandType.StoredProcedure);
                if (result == 0)
                {
                    return 0;
                }
                return result;
            }

        }
    }
}
