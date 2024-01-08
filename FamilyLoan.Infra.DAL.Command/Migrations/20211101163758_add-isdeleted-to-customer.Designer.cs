﻿// <auto-generated />
using System;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyLoan.Infra.DAL.Command.Migrations
{
    [DbContext(typeof(FamilyLoanCommandDbContext))]
    [Migration("20211101163758_add-isdeleted-to-customer")]
    partial class addisdeletedtocustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyLoan.Core.Domain.Accounts.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAccountDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Benefits.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Loans.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<long>("InstallmentAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("Installments");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Loans.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<long>("LoanAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LoanDateStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanNumber")
                        .HasColumnType("int");

                    b.Property<int>("LoanState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Payments.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("BenefitId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("PaymentAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BenefitId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domain.Accounts.Account", b =>
                {
                    b.HasOne("FamilyLoan.Core.Domain.Customers.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Loans.Installment", b =>
                {
                    b.HasOne("FamilyLoan.Core.Domains.Loans.Loan", "Loan")
                        .WithMany("Installments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Loans.Loan", b =>
                {
                    b.HasOne("FamilyLoan.Core.Domain.Customers.Customer", "CustomerLoan")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerLoan");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Payments.Payment", b =>
                {
                    b.HasOne("FamilyLoan.Core.Domain.Accounts.Account", "Account")
                        .WithMany("Payments")
                        .HasForeignKey("AccountId");

                    b.HasOne("FamilyLoan.Core.Domains.Benefits.Benefit", "Benefit")
                        .WithMany("Payments")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Account");

                    b.Navigation("Benefit");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domain.Accounts.Account", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domain.Customers.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Benefits.Benefit", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("FamilyLoan.Core.Domains.Loans.Loan", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}
