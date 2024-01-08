using AutoMapper;
using FamilyLoan.Core.Contracts.Loans;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Loans
{
    public class LoanCommandRepository : ILoanCommandRepository
    {
        private readonly FamilyLoanCommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoanCommandRepository(FamilyLoanCommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Loan AddLoan(Loan loan)
        {

            _dbContext.Loans.Add(loan);
            _dbContext.SaveChanges();
            return loan;
        }

        public void CalculatiingRemainingLoan(int loanId,long installment)
        {
            var loan = _dbContext.Loans.SingleOrDefault(loanid => loanid.Id == loanId);
            loan.RemainingLoan += installment;
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var loan = _dbContext.Loans.SingleOrDefault(loanid => loanid.Id == id);
            loan.IsDeleted = true;
            _dbContext.SaveChanges();
        }

      
        public Loan GetById(int id)
        {
            return _dbContext.Loans.AsNoTracking().SingleOrDefault(loanid => loanid.Id == id);
        }

        public void SaveLoanState(int loanId, LoanState loanState)
        {
            var loan=_dbContext.Loans.SingleOrDefault(loanid => loanid.Id == loanId);
            loan.LoanState = loanState;
           
            _dbContext.SaveChanges();
        }

        public Loan UpdateLoan(Loan Loan)
        {
            var loan = _dbContext.Loans.SingleOrDefault(loanid => loanid.Id == Loan.Id);
            if (loan != null)
            {
                _mapper.Map(Loan, loan);
                _dbContext.SaveChanges();
                return loan;
            }
            else
            {
                return null;
            }
        }

    }
}
