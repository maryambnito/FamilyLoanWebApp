using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contract.Accounts;
using FamilyLoan.Core.Domain.Accounts;
using FamilyLoan.Core.Domain.Accounts.DTO;
using FamilyLoan.Core.Domains.Accounts.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Infra.DAL.Query.Repositories.Common;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Accounts
{
    public class AccountQueryRepository : BaseQueryRepository<Account>, IAccountQueryRepository
    {
        private readonly IMapper _mapper;

        public AccountQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public Account GetById(int id) =>
            _dbContext.Accounts.AsNoTracking()
            .Include(account => account.Customer)
             .SingleOrDefault(accountid => accountid.Id == id);



        public IEnumerable<AccountListItemDTO> GetAll(string Search)=> 
            _dbContext.Accounts.AsNoTracking()
                .Include(account => account.Customer)
                 .Where(accountno => accountno.AccountNO.Contains(Search))
             .OrderBy(accountdate=> accountdate.CreateAccountDate)
                 .ThenBy(accountcustomerid => accountcustomerid.CustomerId)
             .ProjectTo<AccountListItemDTO>(_mapper.ConfigurationProvider).ToList();
            
        public IEnumerable<AccountListItemDTO> GetAllByCustomerId(int customerId) =>
            _dbContext.Accounts.AsNoTracking()
                .Where(account => account.CustomerId == customerId)
                .OrderBy(accountdate => accountdate.CreateAccountDate)
                .ThenBy(accountcustomerid => accountcustomerid.CustomerId)
                .ProjectTo<AccountListItemDTO>(_mapper.ConfigurationProvider).ToList();

        public PagedData<AccountListItemDTO> GetPageAccount(PageParameters pageParameters, string Search)
        {
            return _dbContext.Accounts.AsNoTracking()
                .Include(account => account.Customer)
                .Where(accountno => accountno.AccountNO.Contains(Search))
                .OrderBy(accountdate => accountdate.CreateAccountDate)
                .ThenBy(accountcustomerid => accountcustomerid.CustomerId)
                .ProjectTo<AccountListItemDTO>(_mapper.ConfigurationProvider)
                .GetPagedList(pageParameters);
        }

        public PagedData<AccountsListsDTO> GetPageAccountsList(PageParameters pageParameters)
        {
            return _dbContext.Accounts.AsNoTracking()
                .Include(account => account.Customer)
                .Include(accountpayment => accountpayment.Payments)
                .OrderBy(accountdate => accountdate.CreateAccountDate)
                .ThenBy(accountcustomerid => accountcustomerid.CustomerId)
                .ProjectTo<AccountsListsDTO>(_mapper.ConfigurationProvider)
                .GetPagedList(pageParameters);
        }
    }

}
