using FamilyLoan.Core.Domain.Accounts;
using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Core.Domains.Benefits;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Moeins;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Core.Domains.Roles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FamilyLoan.Infra.DAL.Command.Context
{
    public class FamilyLoanCommandDbContext : IdentityDbContext<Customer, Role,int>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Moein> Moeins { get; set; }
     

        public FamilyLoanCommandDbContext(DbContextOptions<FamilyLoanCommandDbContext> options) : base(options)
        {
        }

     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Payment>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Account>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Loan>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Benefit>().HasQueryFilter(c => c.IsDeleted == false);


            base.OnModelCreating(modelBuilder);
        }

    }
}
