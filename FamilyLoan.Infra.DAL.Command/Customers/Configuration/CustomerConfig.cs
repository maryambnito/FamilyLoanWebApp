using FamilyLoan.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Customers.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired(true);
            builder.HasMany(c => c.Accounts).WithOne(c=>c.Customer).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
