using FamilyLoan.Core.Domains.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Loans.Configuration
{
    public class InstallmentConfig : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(300);

        }
    }
}
