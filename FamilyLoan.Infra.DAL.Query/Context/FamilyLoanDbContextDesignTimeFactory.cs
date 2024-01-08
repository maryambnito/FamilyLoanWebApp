using Microsoft.EntityFrameworkCore.Design;

namespace FamilyLoan.Infra.DAL.Query.Context
{
    public class FamilyLoanDbContextDesignTimeFactory : IDesignTimeDbContextFactory<FamilyLoanQueryDbContext>
    {
        public FamilyLoanQueryDbContext CreateDbContext(string[] args) => ContextFactory.GetSqlContext();
        
    }
}
