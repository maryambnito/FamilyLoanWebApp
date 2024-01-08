using FamilyLoan.Core.Domain.Accounts;
using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Core.Domains.Benefits;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Moeins;
using FamilyLoan.Core.Domains.Payments;
using Microsoft.EntityFrameworkCore;

namespace FamilyLoan.Infra.DAL.Query.Context
{
    public class FamilyLoanQueryDbContext : DbContext
    {
        
        public DbSet<Customer> AspNetUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Moein>  Moeins{ get; set; }

        public FamilyLoanQueryDbContext(DbContextOptions<FamilyLoanQueryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Account>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Loan>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Benefit>().HasQueryFilter(c => c.IsDeleted == false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
