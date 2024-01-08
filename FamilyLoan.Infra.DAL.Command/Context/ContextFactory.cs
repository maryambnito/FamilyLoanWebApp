using Microsoft.EntityFrameworkCore;

namespace FamilyLoan.Infra.DAL.Command.Context
{
    public static class ContextFactory
    {
        public static FamilyLoanCommandDbContext GetSqlContext()
        {
            var builder = new DbContextOptionsBuilder<FamilyLoanCommandDbContext>();
            builder.UseSqlServer("Server=.;Database=FamilyLoan2021;Integrated Security=True;MultipleActiveResultSets=true");
            return new FamilyLoanCommandDbContext(builder.Options);
        }
    }
}
