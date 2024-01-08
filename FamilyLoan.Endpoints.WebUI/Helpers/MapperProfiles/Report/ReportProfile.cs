using AutoMapper;
using FamilyLoan.Core.ApplicationServices.Loans.Queries.loans.GetAllLoansState;
using FamilyLoan.Core.Domain.Accounts.DTO;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Core.Domains.Reports.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Reports;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Report
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ShowLoanReportViewModel, GetAllLoanByStateQuery>();
            CreateMap<AccountListItemDTO, ReportDTO>();
            CreateMap<GetAllLoanByStateQuery,LoansStateDTO>();

        }
    }
}
