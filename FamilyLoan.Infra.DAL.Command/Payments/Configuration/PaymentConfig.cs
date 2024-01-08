using FamilyLoan.Core.Domains.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyLoan.Infra.DAL.Command.Payments.Configuration
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {

        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(350);


        }
    }
}
