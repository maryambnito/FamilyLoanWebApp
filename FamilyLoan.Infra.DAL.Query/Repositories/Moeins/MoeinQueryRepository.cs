using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Moeins;
using FamilyLoan.Core.Domains.Moeins.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Moeins
{
    public class MoeinQueryRepository : IMoeinQueryRepository
    {
        private readonly FamilyLoanQueryDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoeinQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public PagedData<MoeinDTO> GetPagedMoein(PageParameters pageParameters, string Search) =>
         _dbContext.Moeins.AsNoTracking()
                .Where(moeinDescription => moeinDescription.Description.Contains(Search))
                .OrderBy(moein => moein.Date)
                .ProjectTo<MoeinDTO>(_mapper.ConfigurationProvider).GetPagedList(pageParameters);


        public MoeinDTO GetById(int id) =>
            _dbContext.Moeins.AsNoTracking()
                   .ProjectTo<MoeinDTO>(_mapper.ConfigurationProvider)
                   .SingleOrDefault(moien => moien.Id == id);

        public IEnumerable<MoeinDTO> GetAll() => _dbContext.Moeins.AsNoTracking()
            .OrderBy(moein => moein.Date).ProjectTo<MoeinDTO>(_mapper.ConfigurationProvider).ToList();

        public long? GetLastSum()
        {
            var lastSumMoein = _dbContext.Moeins.OrderBy(moein => moein.Date).LastOrDefault();
            return lastSumMoein.Sum;
        }
    }
}
