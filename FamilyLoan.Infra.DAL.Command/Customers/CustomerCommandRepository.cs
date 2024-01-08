using AutoMapper;
using FamilyLoan.Core.Contract.Customers;
using FamilyLoan.Core.Domain.Customers;
using FamilyLoan.Infra.DAL.Command.Common;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Customers
{
    public class CustomerCommandRepository : BaseCommandRepository<Customer>, ICustomerCommandRepository
    {
        private readonly IMapper _mapper;
        public CustomerCommandRepository(FamilyLoanCommandDbContext dbContext, 
            IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

       
        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
    
        public void Delete(int id)
        {

            Customer customer = _dbContext.Customers.SingleOrDefault(customerid => customerid.Id == id);

            customer.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.AsNoTracking().FirstOrDefault(customerid => customerid.Id == id);
        }

        public void Savechange()
        { 
            _dbContext.SaveChanges();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var Customer = _dbContext.Customers.SingleOrDefault(customerid => customerid.Id == customer.Id);
            if (Customer != null)
            {
                _mapper.Map(customer, Customer);
               
                _dbContext.SaveChanges();
                return Customer;
            }
            else
            {
                return null;

            }

        }



    }
}
