
using FamilyLoan.Core.ApplicaionService.Customers.Queries.GetAllCustomers;
using FamilyLoan.Core.ApplicationServices.Accounts.Services;
using FamilyLoan.Core.ApplicationServices.Loans.InstallmentServices;
using FamilyLoan.Core.ApplicationServices.Loans.LoanServices;
using FamilyLoan.Core.ApplicationServices.Moeins.Services;
using FamilyLoan.Core.ApplicationServices.Payments.PaymentServices;
using FamilyLoan.Core.Contract.Accounts;
using FamilyLoan.Core.Contract.Customers;
using FamilyLoan.Core.Contracts.Accounts;
using FamilyLoan.Core.Contracts.Benefits;
using FamilyLoan.Core.Contracts.Loans;
using FamilyLoan.Core.Contracts.Loans.Services;
using FamilyLoan.Core.Contracts.Moeins;
using FamilyLoan.Core.Contracts.Payments;
using FamilyLoan.Core.Contracts.Reports;
using FamilyLoan.Endpoints.WebUI.Infra.Filters;
using FamilyLoan.Endpoints.WebUI.VIewModels.Customers;
using FamilyLoan.Infra.DAL.Command.Accounts;
using FamilyLoan.Infra.DAL.Command.Benefits;
using FamilyLoan.Infra.DAL.Command.Customers;
using FamilyLoan.Infra.DAL.Command.Loans;
using FamilyLoan.Infra.DAL.Command.Moeins;
using FamilyLoan.Infra.DAL.Command.Payments;
using FamilyLoan.Infra.DAL.Query.Repositories.Accounts;
using FamilyLoan.Infra.DAL.Query.Repositories.Benfits;
using FamilyLoan.Infra.DAL.Query.Repositories.Customers;
using FamilyLoan.Infra.DAL.Query.Repositories.Loans;
using FamilyLoan.Infra.DAL.Query.Repositories.Loans.LoanSp;
using FamilyLoan.Infra.DAL.Query.Repositories.Moeins;
using FamilyLoan.Infra.DAL.Query.Repositories.Payments;
using FamilyLoan.Infra.DAL.Query.Repositories.Reports;
using FamilyLoan.Utilities.Paging;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyLoan.Endpoints.WebUI.Helpers

{
    public static class RegiaterAllDependecies
    {
        public static void ConfigureAppRepositories(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<PageParameters>(opt => configuration.GetSection("PageParameters").Bind(opt));
            services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(typeof(ExceptionHandelFilter));
            })./*AddRazorRuntimeCompilation().*/
          AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>());

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(GetAllCustomerHandler).Assembly);
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();

            services.AddScoped<IAccountCommandRepository, AccountCommandRepository>();
            services.AddScoped<IAccountQueryRepository, AccountQueryRepository>();

            services.AddScoped<IAccountsService, AccountsService>();

            services.AddScoped<ILoanQueryRepository, LoanQueryRepository>();
            services.AddScoped<ILoanCommandRepository, LoanCommandRepository>();
            services.AddScoped<ILoansServices, LoansService>();
            services.AddScoped<ICalcutingAllLoansQueryRepository, DapperAllLoansQueryRepository>();

            services.AddScoped<IInstallmentQueryRepository, InstallmentQueryRepository>();
            services.AddScoped<IInstallmentCommandRepository, InstallmentCommandRepository>();
            services.AddScoped<IInstallmentServices, InstallmentService>();

            services.AddScoped<IPaymentQueryRepository, PaymentQueryRepository>();
            services.AddScoped<IPaymentCommandRepository, PaymentCommandRepository>();
            services.AddScoped<IPaymentServce, PaymentService>();
            services.AddScoped<ICalcutingPaymentQueryRepository, DapperPaymentQueryRepository>();

            services.AddScoped<IBenefitQueryRepository, BenfitQueryRepository>();
            services.AddScoped<IBenefitCommandRepository, BenfitCommandRepository>();
            
            
            
            services.AddScoped<IMoeinCommandRepository, MoeinCommandRepository>();
            services.AddScoped<IMoeinQueryRepository, MoeinQueryRepository>();
            services.AddScoped<IMoeinService, MoeinService>();
            services.AddScoped<IReportQueryRepository, DapperReportQueryRepository>();

        }
    }
}