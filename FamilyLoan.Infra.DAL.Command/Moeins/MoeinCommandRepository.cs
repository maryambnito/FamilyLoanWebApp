using AutoMapper;
using FamilyLoan.Core.Contracts.Moeins;
using FamilyLoan.Core.Domains.Moeins;
using FamilyLoan.Infra.DAL.Command.Context;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Moeins
{
    public class MoeinCommandRepository : IMoeinCommandRepository
    {
        protected readonly FamilyLoanCommandDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoeinCommandRepository(FamilyLoanCommandDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Moein AddMoein(Moein moein)
        {
            _dbContext.Moeins.Add(moein);
            _dbContext.SaveChanges();
            return moein;
        }



        public void Delete(int id)
        {
            var moein = _dbContext.Moeins.SingleOrDefault(moeinId => moeinId.Id == id);
            _dbContext.Moeins.Remove(moein);
            _dbContext.SaveChanges();

        }


        public void UpdateMoein(int Id, string Description)
        {
            var Moein = _dbContext.Moeins.SingleOrDefault(moeinId => moeinId.Id == Id);
            Moein.Description = Description;
            _dbContext.SaveChanges();

        }

        public void SumMoeinDTOsByDate(int id)
        {
          
            Moein moein = _dbContext.Moeins.SingleOrDefault(moeinId => moeinId.Id == id);
            var moeinsSub = _dbContext.Moeins
                .Where(moeinssub => moeinssub.Date <= moein.Date && moeinssub.Id != moein.Id).ToList();
            var moeinsPlus = _dbContext.Moeins
           .Where(moeinsplus => moeinsplus.Date > moein.Date).ToList();

            if (moeinsSub.Count != 0)
            {
                  var moeinsSubresult = moeinsSub.OrderBy(moeinssubDate => moeinssubDate.Date)
                    .Last();
                if(moeinsSubresult!=null)
                    moein.Sum += moeinsSubresult.Sum;
               
            };
           
            if (moeinsPlus.Count != 0)
            {
                foreach (var item in moeinsPlus)
                {
                    item.Sum += moein.Debtor + moein.Creditor;
                }
            }
              
                _dbContext.SaveChanges();

        }

        public void DeleteMoeinDTOs(int Id)
        {
            Moein moein = _dbContext.Moeins.SingleOrDefault(moeinId => moeinId.Id == Id);
            var moeins = _dbContext.Moeins.Where(moeinDate => moeinDate.Date >= moein.Date
             && moeinDate.Id != moein.Id).ToList();
            if (moeins.Count != 0)
            {

                foreach (var item in moeins)
                {
                    item.Sum -= moein.Debtor + moein.Creditor;
                };
            }
            _dbContext.SaveChanges();
        }
    }
}
