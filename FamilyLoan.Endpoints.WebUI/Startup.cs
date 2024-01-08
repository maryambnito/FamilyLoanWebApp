using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Core.Domains.Roles;
using FamilyLoan.Endpoints.WebUI.Helpers;
using FamilyLoan.Infra.DAL.Command.Context;
using FamilyLoan.Infra.DAL.Query.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FamilyLoan.Endpoints.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FamilyLoanCommandDbContext>
               (opt => opt.UseSqlServer(Configuration.GetConnectionString("FamilyLoanCommand")));
            services.AddDbContext<FamilyLoanQueryDbContext>
                (opt => opt.UseSqlServer(Configuration.GetConnectionString("FamilyLoanQuery")));
            services.ConfigureAppRepositories(Configuration);
           
            services.AddIdentity<Customer, Role>(opt => {
                opt.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPQRSTUYWVXZqwertyuiopasdfghjklzxcvbnm-_123456789";
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            }).AddEntityFrameworkStores<FamilyLoanCommandDbContext>()
            .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(opt => {
                opt.LoginPath = "/login";
                opt.SlidingExpiration = true;
                opt.AccessDeniedPath = "/accessdeniefd";
                opt.ExpireTimeSpan = TimeSpan.FromHours(8);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/error");
            }


            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

