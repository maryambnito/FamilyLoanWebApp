using FamilyLoan.Domain.Contract.Com;
using FamilyLoan.Infra.DAL.Query.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Common
{
    public class BaseQueryRepository<TEntity> : IBaseQueryRepository<TEntity> where TEntity : class
    {
        protected readonly FamilyLoanQueryDbContext _dbContext;

        public BaseQueryRepository(FamilyLoanQueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CheckExisting(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Any(predicate);

        }

      
    }
}
