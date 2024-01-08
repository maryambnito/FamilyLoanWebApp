using FamilyLoan.Core.Domains.Benefits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Benefits.Configuration
{
    public class BenefitConfig : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.HasMany(c => c.Payments).WithOne(c => c.Benefit).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
