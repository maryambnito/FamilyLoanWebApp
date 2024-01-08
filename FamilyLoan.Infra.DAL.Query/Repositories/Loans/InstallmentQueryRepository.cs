using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Loans;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Infra.DAL.Query.Repositories.Common;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Loans
{
    public class InstallmentQueryRepository : BaseQueryRepository<Installment>,IInstallmentQueryRepository
    {
        private readonly IMapper _mapper;
        public InstallmentQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public InstallmentDTO GetById(int Id) => 
            _dbContext.Installments.AsNoTracking().Where(installment => installment.IsDeleted == false)
                .ProjectTo<InstallmentDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefault(installmentid => installmentid.Id == Id);

        public IEnumerable<InstallmentDTO> GetAll() => 
            _dbContext.Installments.AsNoTracking()
                .Where(installment => installment.IsDeleted == false)
            .OrderBy(installmentdate => installmentdate.InstallmentDate)
                .ProjectTo<InstallmentDTO>(_mapper.ConfigurationProvider).ToList();

        public IEnumerable<InstallmentDTO> GetInstallmentByLoanId(DateTime? fromDate, DateTime? toDate, int LoanId)
        {
            var query = _dbContext.Installments.AsNoTracking()
                .Where(installmentloanId => installmentloanId.LoanId == LoanId
            && installmentloanId.IsDeleted ==false)
                .OrderBy(installmentdate=>installmentdate.InstallmentDate)
                .ProjectTo<InstallmentDTO>(_mapper.ConfigurationProvider);

            if (fromDate == default && toDate != default)
            {
                query = query.Where(installmentdate => installmentdate.InstallmentDate < toDate);

            }
            else
        if (toDate == default && fromDate != default)
            {
                query = query.Where(installmentdate => installmentdate.InstallmentDate >= fromDate);

            }
            else
         if (toDate != default && fromDate != default)
            {

                query = query.Where(installmentdate => installmentdate.InstallmentDate >= fromDate
                && installmentdate.InstallmentDate <= toDate);
            }

         

            return query.ToList();
           
        }

       

        public PagedData<InstallmentDTO> GetPageInstalment(PageParameters pageParameters)
        {
            return _dbContext.Installments.AsNoTracking()
                .Where(installment => installment.IsDeleted == true)
                    .ProjectTo<InstallmentDTO>(_mapper.ConfigurationProvider)
                    .GetPagedList(pageParameters);
        }
    }
}
