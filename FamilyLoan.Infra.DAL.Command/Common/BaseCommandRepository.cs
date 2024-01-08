using FamilyLoan.Core.Contracts.Common;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FamilyLoan.Infra.DAL.Command.Common
{
    public class BaseCommandRepository<TEntity> : IBaseCommandRepository<TEntity> where TEntity : class
    {
        protected readonly FamilyLoanCommandDbContext _dbContext;

        public BaseCommandRepository(FamilyLoanCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CheckExisting(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Any(predicate);

        }

    }
}
