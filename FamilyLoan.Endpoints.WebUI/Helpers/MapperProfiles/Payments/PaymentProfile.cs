using AutoMapper;
using FamilyLoan.Core.ApplicationService.Accounts.Query.GetAccountById;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.AddPayments;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsByAccountId;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetTotalPayments;
using FamilyLoan.Core.Domain.Accounts.DTO;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Core.Domains.Payments.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments;
using FamilyLoan.Endpoints.WebUI.VIewModels.Payments;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Payments
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<AccountListItemDTO, CreatePaymentViewModel>()
               .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId));

            CreateMap<GetPaymentByAccountIdQuery, ShowPaymentsViewModel>();

            CreateMap<Payment, PaymentDTO>();
            CreateMap<Payment, Payment>();
           
            CreateMap<PaymentDTO, Payment>();
            CreateMap<PaymentDTO, DeletePaymentAccountViewModel>();
            CreateMap<PaymentDTO, DetailsPaymentAccountViewModel>();
            CreateMap<PaymentDTO, AddPaymentCommand>();
            CreateMap<PaymentDTO, PaymentAccountListVIewModel>();

            CreateMap<AddPaymentCommand, PaymentDTO>();
            CreateMap<AddPaymentCommand, AddPaymentViewModel>();

            CreateMap<AddPaymentViewModel, AddPaymentCommand>();
            CreateMap<AddPaymentViewModel, GetPaymentByAccountIdQuery>();

            CreateMap<GetAccountByIdQuery, AddPaymentViewModel>();
            CreateMap<ShowPaymentsViewModel, GetPaymentByAccountIdQuery>();
            CreateMap<ShowPaymentsViewModel, GetTotalPaymentsQuery>();
           
          
        
            CreateMap<InstallmentDTO, DetailsPaymentAccountViewModel>();


      







        }
    }
}
