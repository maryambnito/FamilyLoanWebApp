using AutoMapper;
using FamilyLoan.Core.Contracts.Benefits;
using FamilyLoan.Core.Domains.Benefits;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Benefits
{
    public class BenfitCommandRepository: IBenefitCommandRepository
    {
        private readonly FamilyLoanCommandDbContext _dbContext;
        private readonly IMapper _mapper;
        public BenfitCommandRepository(FamilyLoanCommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        } 
        public Benefit AddBenefit(Benefit benefit)
        {
            _dbContext.Benefits.Add(benefit);
            _dbContext.SaveChanges();
            return benefit;
        }

        public void Delete(int id)
        {
            Benefit benefit = _dbContext.Benefits.FirstOrDefault(benefitt=>benefitt.Id==id);
            benefit.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public Benefit GetById(int id)
        {
            return _dbContext.Benefits.AsNoTracking().FirstOrDefault(benefitid => benefitid.Id == id);
        }

        public Benefit UpdateBenefit(Benefit benefit)
        {
            var Benefit = _dbContext.Benefits.SingleOrDefault(benefitid => benefitid.Id == benefit.Id);
            if (Benefit != null)
            {
                _mapper.Map(benefit, Benefit);

                _dbContext.SaveChanges();
                return Benefit;
            }
            else
            {
                return null;

            }
        }
    }
}
