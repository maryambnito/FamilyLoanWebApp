using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Benefits;
using FamilyLoan.Core.Domains.Benefits.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Benfits
{
    public class BenfitQueryRepository : IBenefitQueryRepository
    {
        private readonly IMapper _mapper;
        private readonly FamilyLoanQueryDbContext _dbContext;

        public BenfitQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }



        public BenefitDTO Get()
        {
            var result = _dbContext.Benefits.FirstOrDefault();
            BenefitDTO benefitDTO = _mapper.Map<BenefitDTO>(result);
            return benefitDTO;

        }



        public BenefitDTO GetById(int id) => 
            _dbContext.Benefits.AsNoTracking().Include(benefit => benefit.Payments)
               .ProjectTo<BenefitDTO>(_mapper.ConfigurationProvider)
               .SingleOrDefault(benefitid => benefitid.Id == id);

      
    }
}
