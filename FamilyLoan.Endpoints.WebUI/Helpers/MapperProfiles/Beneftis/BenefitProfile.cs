using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Benefits.Command.AddBenefits;
using FamilyLoan.Core.ApplicationServices.Benefits.Command.UpdateBenefits;
using FamilyLoan.Core.ApplicationServices.Payments.Commands.AddPayments;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsByAccountId;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetPaymentsByBenefitId;
using FamilyLoan.Core.ApplicationServices.Payments.Queries.GetTotalPayments;
using FamilyLoan.Core.Domains.Benefits;
using FamilyLoan.Core.Domains.Benefits.DTO;
using FamilyLoan.Core.Domains.Payments.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Benefits;
using FamilyLoan.Endpoints.WebUI.VIewModels.Benefits.BenefitPayments;
using FamilyLoan.Endpoints.WebUI.VIewModels.Payments;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Beneftis
{
    public class BenefitProfile : Profile
    {
        public BenefitProfile()
        {


            CreateMap<BenefitDTO, Benefit>();
            CreateMap<PaymentDTO, DetailsPaymentBenefitViewModel>();
            CreateMap<BenefitDTO, DeleteBenefitViewModel>();
            CreateMap<Benefit, BenefitDTO>();
            CreateMap<Benefit, Benefit>();
            CreateMap<AddBenefitCommand, Benefit>();
            CreateMap<UpdateBenefitCommand, Benefit>();
            CreateMap<AddBenefitsViewModel, AddBenefitCommand>();
            CreateMap<UpdateBenefitsViewModel, UpdateBenefitCommand>();
            CreateMap<AddPaymentBenefitViewModel, AddPaymentCommand>();
            CreateMap<GetPaymentsByBenefitIdQuery, ShowBenefitPaymentsModelView>();
            CreateMap<ShowBenefitPaymentsModelView, GetPaymentsByBenefitIdQuery>();
            CreateMap<ShowBenefitPaymentsModelView, GetPaymentByAccountIdQuery>();
            CreateMap<ShowBenefitPaymentsModelView, GetTotalPaymentsQuery>();

        }

    }
}
