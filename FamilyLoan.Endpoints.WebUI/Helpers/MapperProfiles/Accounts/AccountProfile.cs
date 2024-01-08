using AutoMapper;
using FamilyLoan.Core.ApplicationService.Accounts.Command.UpdateAccounts;
using FamilyLoan.Core.AppplicationService.Accounts.Command.AddAccounts;
using FamilyLoan.Core.Domain.Accounts;
using FamilyLoan.Core.Domain.Accounts.DTO;
using FamilyLoan.Core.Domains.Accounts.DTO;
using FamilyLoan.Endpoints.WebUI.VIewModels.Accounts;

namespace FamilyLoan.Endpoints.WebUI.Helpers.MapperProfiles.Accounts
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId));


            CreateMap<AccountListItemDTO, AccountsListsDTO>();
            CreateMap<Account, AccountListItemDTO>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName));

            CreateMap<Account, AccountsListsDTO>()
              .ForMember(d => d.FullName, o => o.MapFrom(s => s.Customer.FirstName + " " + s.Customer.LastName));

            CreateMap<AddAccountCommand, Account>();

            CreateMap<CreateAccountPostViewModel, AddAccountCommand>();

            CreateMap<UpdateAccountCommand, AccountDTO>();

            CreateMap<UpdateAccountCommand, Account>();

            CreateMap<AccountDTO, UpdateAccountCommand>();

            CreateMap<AccountDTO, UpdateAccountViewModel>();

            CreateMap<Account, Account>();

            CreateMap<UpdateAccountViewModel, UpdateAccountCommand>()
                .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId));

            CreateMap<UpdateAccountViewModel, Account>();
            CreateMap<DeleteAccountViewModel, Account>();
            CreateMap<DeleteAccountViewModel, AccountDTO>();

            CreateMap<AccountDTO, DeleteAccountViewModel>();
            CreateMap<AccountDTO, DetailsAccountViewModel>();



        }
    }
}
