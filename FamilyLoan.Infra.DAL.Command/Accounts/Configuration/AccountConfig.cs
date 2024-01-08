using FamilyLoan.Core.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Accounts.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(350);
            builder.HasKey(c => c.Id);


        }
    }
}
