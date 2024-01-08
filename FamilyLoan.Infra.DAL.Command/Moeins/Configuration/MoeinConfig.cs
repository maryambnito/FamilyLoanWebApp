using FamilyLoan.Core.Domains.Moeins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Moeins.Configuration
{
    public class MoeinConfig : IEntityTypeConfiguration<Moein>
    {


        public void Configure(EntityTypeBuilder<Moein> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired(true);


        }
    }

}
