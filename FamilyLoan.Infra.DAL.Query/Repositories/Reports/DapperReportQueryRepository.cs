using Dapper;
using FamilyLoan.Core.Contracts.Reports;
using FamilyLoan.Core.Domains.Reports.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Reports
{
    public class DapperReportQueryRepository : IReportQueryRepository
    {
        private readonly string connectionstring;

        public DapperReportQueryRepository(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("FamilyLoanQuery");

        }

        public List<MoeinKolReportDTO> GetAllInfo(string search)
        {
            ReportSPinput obj = new() { search = search };
            using (var connection = new SqlConnection(connectionstring))
            {
                var spName = "[dbo].[MoeinKol]";
                var result = connection.
                    Query<MoeinKolReportDTO>(spName, obj, commandType: System.Data.CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
