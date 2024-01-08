using AutoMapper;
using FamilyLoan.Core.Contract.Accounts;
using FamilyLoan.Core.Domain.Accounts;
using FamilyLoan.Infra.DAL.Command.Common;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Accounts
{
    public class AccountCommandRepository : BaseCommandRepository<Account>, IAccountCommandRepository
    {
        private readonly FamilyLoanCommandDbContext _dbcontext;
        private readonly IMapper _mapper;

        public AccountCommandRepository(FamilyLoanCommandDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public Account AddAccount(Account account)
        {
            _dbcontext.Accounts.Add(account);
            _dbcontext.SaveChanges();
            return account;
        }

        public void Delete(int id)
        {
            Account account = _dbcontext.Accounts.SingleOrDefault(accountid => accountid.Id == id);

            account.IsDeleted = true; 
            _dbcontext.SaveChanges();
        }

        public Account GetById(int id)
        {
            return _dbcontext.Accounts.AsNoTracking().SingleOrDefault(accountid => accountid.Id == id);
        }

        public Account UpdateAccount(Account account)
        {
            var Account = _dbcontext.Accounts.SingleOrDefault(accountid => accountid.Id == account.Id);
            if (Account != null)
            {
                _mapper.Map(account, Account);

                _dbcontext.SaveChanges();
                return Account;
            }
            else
            {
                return null;

            }


        }

    }
}
