using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Loans;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Core.Domains.Loans.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Loans
{
    public class LoanQueryRepository : ILoanQueryRepository
    {
        private readonly FamilyLoanQueryDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoanQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public LoanDTO GetById(int id) => _dbContext.Loans.AsNoTracking()
                .ProjectTo<LoanDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefault(loan => loan.Id == id);


        public List<LoanListItemDTO> GetAll() =>
            _dbContext.Loans.AsNoTracking().Include(c => c.CustomerLoan)
                .ProjectTo<LoanListItemDTO>(_mapper.ConfigurationProvider).ToList();

        public List<LoanListItemDTO> GetAllLoansByState(LoansStateDTO loansByStateDTO)
        {
            var result = _dbContext.Loans.AsNoTracking().Include(loan => loan.CustomerLoan)
                .OrderByDescending(loansort=>loansort.LoanDateStart)
                .ProjectTo<LoanListItemDTO>(_mapper.ConfigurationProvider);

            if (loansByStateDTO.FromDate == default && loansByStateDTO.ToDate != default)
            {
                result = result.Where(loandate => loandate.LoanDateStart < loansByStateDTO.ToDate);

            }
            else
              if (loansByStateDTO.ToDate == default && loansByStateDTO.FromDate != default)
            {
                result = result.Where(loandate => loandate.LoanDateStart >= loansByStateDTO.FromDate);

            }
            else
            if (loansByStateDTO.ToDate != default && loansByStateDTO.FromDate != default)
            {

                result = result.Where(loandate => loandate.LoanDateStart >= loansByStateDTO.FromDate &&
                loandate.LoanDateStart <= loansByStateDTO.ToDate);
            }
            if (loansByStateDTO.LoanState != default)
            {
                result = result.Where(loanstate => loanstate.LoanState == loansByStateDTO.LoanState);

            }
            if (loansByStateDTO.CustomerId != default)
            {
                result = result.Where(loancustomer => loancustomer.CustomerId == loansByStateDTO.CustomerId);

            }
            return result.ToList();
        }

        public PagedData<LoanListItemDTO> GetPageLoan(PageParameters pageParameters, string search)
        {
            return _dbContext.Loans.AsNoTracking()
                .Include(loan => loan.CustomerLoan)
                .OrderBy(loandate => loandate.LoanDateStart)
                .Where(loancustomer => loancustomer.CustomerLoan.LastName.Contains(search)
                || loancustomer.CustomerLoan.FirstName.Contains(search))
                .ProjectTo<LoanListItemDTO>(_mapper.ConfigurationProvider).GetPagedList(pageParameters);
        }

        public List<LoanListItemDTO> GetAllLoansByCustomerId(int customerId) =>
            _dbContext.Loans.Where(loan => loan.CustomerId == customerId
              && loan.LoanState != LoanState.Done).ProjectTo<LoanListItemDTO>
            (_mapper.ConfigurationProvider).ToList();

    }
}
