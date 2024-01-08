using Microsoft.EntityFrameworkCore;

namespace FamilyLoan.Infra.DAL.Query.Context
{
    public static class ContextFactory
    {
        public static FamilyLoanQueryDbContext GetSqlContext()
        {
            var builder = new DbContextOptionsBuilder<FamilyLoanQueryDbContext>();
            builder.UseSqlServer("Server=.;Database=FamilyLoans;Integrated Security=True;MultipleActiveResultSets=true");
            return new FamilyLoanQueryDbContext(builder.Options);
        }
    }
}
