using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.loans.AddLLoans;
using FamilyLoan.Core.ApplicationServices.Loans.Commands.loans.UpdateLoans;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetAllLoan;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetLoanByID;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Loans;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Loans.loans
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, Loan>();
            CreateMap<Loan, LoanDTO>();
            CreateMap<Loan, LoanListItemDTO>();
            CreateMap<LoanDTO, LoanListItemDTO>();
            CreateMap<LoanDTO, DeleteLoanVIewModel>();
            CreateMap<AddLoanCommand, Loan>();
            CreateMap<LoanListItemDTO, UpdateLoanViewModel>();
            CreateMap<LoanListItemDTO, DeleteLoanVIewModel>();
            CreateMap<LoanDTO, DetailsLoanVIewModel>();
            CreateMap<UpdateLoanCommand, Loan>();
            CreateMap<GetLoanByIdQuery, Loan>();
            CreateMap<GetAllLoanQuery, Loan>();
            CreateMap<CreateLoanVIewModel, AddLoanCommand>();
            CreateMap<LoanDTO,UpdateLoanViewModel>();
            CreateMap<UpdateLoanViewModel, UpdateLoanCommand>();
            CreateMap<Loan, LoanListItemDTO>()
                   .ForMember(d => d.FullName, o => o.MapFrom(s => s.CustomerLoan.FirstName + " " + s.CustomerLoan.LastName));

        }
    }
}
