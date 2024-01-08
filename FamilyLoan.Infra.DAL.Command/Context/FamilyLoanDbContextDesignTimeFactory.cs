using Microsoft.EntityFrameworkCore.Design;

namespace FamilyLoan.Infra.DAL.Command.Context
{
    public class FamilyLoanDbContextDesignTimeFactory : IDesignTimeDbContextFactory<FamilyLoanCommandDbContext>
    {
        public FamilyLoanCommandDbContext CreateDbContext(string[] args) => ContextFactory.GetSqlContext();
    }
}
