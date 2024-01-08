using AutoMapper;
using FamilyLoan.Core.Contracts.Loans;
using FamilyLoan.Core.Domains.Loans;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Loans
{
    public class InstallmentCommandRepository : IInstallmentCommandRepository
    {
        private readonly FamilyLoanCommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public InstallmentCommandRepository(FamilyLoanCommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Installment AddInstallment(Installment installment)
        {
            _dbContext.Installments.Add(installment);
            _dbContext.SaveChanges();
            return installment;
        }

        public void Delete(int id)
        {

            var Installment = _dbContext.Installments.SingleOrDefault(installmentid => installmentid.Id == id);
            Installment.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public Installment GetById(int id)
        {
            return _dbContext.Installments.AsNoTracking().SingleOrDefault(installmentid => installmentid.Id == id);
        }

        public Installment UpdateInstallment(Installment installment)
        {
            var Installment = _dbContext.Installments
                .SingleOrDefault(installmentid => installmentid.Id == installment.Id);
            if (Installment != null)
            {
                _mapper.Map(installment, Installment);
                _dbContext.SaveChanges();
                return Installment;
            }
            else
            {
                return null;
            }
        }
       

    }
}
