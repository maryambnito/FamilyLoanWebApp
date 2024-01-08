using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contract.Customers;
using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Core.Domain.Customers.DTOs;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Infra.DAL.Query.Repositories.Common;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Customers

{
    public class CustomerQueryRepository : BaseQueryRepository<Customer>, ICustomerQueryRepository
    {
        private readonly IMapper _mapper;

        public CustomerQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public CustomerDTO GetById(int id) => _dbContext.AspNetUsers.AsNoTracking()
                .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefault(customer => customer.Id == id);

        public List<CustomerDTO> GetAll()=>_dbContext.AspNetUsers.AsNoTracking()
             .Include(customer => customer.Accounts).Include(loan =>loan.Loans)            
                 .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider).ToList();
         

       

        public PagedData<CustomerDTO> GetPageCustomer(PageParameters pageParameters, string Search) =>
            _dbContext.AspNetUsers.AsNoTracking()
                .Where(customer => customer.FirstName.Contains(Search) || customer.LastName.Contains(Search))
                .OrderByDescending(customerid => customerid.Id)
                  .ProjectTo<CustomerDTO>(_mapper.ConfigurationProvider).GetPagedList(pageParameters);



    }
}
