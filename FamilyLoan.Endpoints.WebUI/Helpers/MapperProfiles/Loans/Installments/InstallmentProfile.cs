using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.Installments.AddInstallments;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.Installments.GetInstallmentByLoanId;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.Installments.SumInstallmentByLoanId;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetTotalLoansAmount.GetRemainingLoanById;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Payments;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Loans.Installments
{
    public class InstallmentProfile : Profile
    {
        public InstallmentProfile()
        {
            CreateMap<Installment, InstallmentDTO>();
            CreateMap<AddInstallmentCommand, Installment>();
            CreateMap<ShowInstallmentViewModel, GetInstallmentByLoanIdQuery>();
            CreateMap<AddInstallmentViewModel, AddInstallmentCommand>();
            CreateMap<ShowInstallmentViewModel, GetTotalLoanAmountQuery>();
            CreateMap<ShowInstallmentViewModel, GetSumInstallmentByLoanIdQuery>();
        }
    }
}
