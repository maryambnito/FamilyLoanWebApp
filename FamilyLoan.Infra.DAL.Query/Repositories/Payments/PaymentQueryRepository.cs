using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Payments;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Core.Domains.Payments.DTO;
using FamilyLoan.Infra.DAL.Query.Context;
using FamilyLoan.Infra.DAL.Query.Repositories.Common;
using FamilyLoan.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Query.Repositories.Payments
{
    public class PaymentQueryRepository : BaseQueryRepository<Payment>
        , IPaymentQueryRepository

    {
        private readonly IMapper _mapper;

        public PaymentQueryRepository(FamilyLoanQueryDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }





        public IEnumerable<PaymentDTO> GetAll() => _dbContext.Payments.AsNoTracking().
                   ProjectTo<PaymentDTO>(_mapper.ConfigurationProvider).ToList();

        public PaymentDTO GetById(int id) => _dbContext.Payments
                .ProjectTo<PaymentDTO>(_mapper.ConfigurationProvider)
                   .SingleOrDefault(payment => payment.Id == id);




        public PagedData<PaymentDTO> GetPagePayments(PageParameters pageParameters)
        {
            return _dbContext.Payments.AsNoTracking()
                .Where(payment => payment.PaymentType == PaymentType.Account)
               .Include(paymentaccount => paymentaccount.Account)
               .ThenInclude(paymentcustomer => paymentcustomer.Customer.FirstName)
                .OrderBy(paymentdate => paymentdate.PaymentDate).ProjectTo<PaymentDTO>(_mapper.ConfigurationProvider)
                .GetPagedList(pageParameters);
          
        }

       

        public IEnumerable<Payment> GetPaymentsByBenefitId(DateTime? fromDate, DateTime? toDate, int BenefitId)
        {
            var query = _dbContext.Payments.AsNoTracking()
                .Where(payment => payment.BenefitId == BenefitId);


            if (fromDate == default && toDate != default)
            {
                query = query.Where(paymentdate => paymentdate.PaymentDate < toDate);

            }
            else
           if (toDate == default && fromDate != default)
            {
                query = query.Where(paymentdate => paymentdate.PaymentDate >= fromDate);

            }
            else
            if (toDate != default && fromDate != default)
            {

                query = query.Where(c => c.PaymentDate >= fromDate && c.PaymentDate <= toDate);
            }

            return query.OrderBy(paymentdate => paymentdate.PaymentDate).ToList();
        }

        public IEnumerable<Payment> GetPaymentsByAccountId(DateTime? fromDate, DateTime? toDate, int accountId)
        {


            var query = _dbContext.Payments.AsNoTracking().Where(payment => payment.AccountId == accountId);


            if (fromDate == default && toDate != default)
            {
                query = query.Where(paymentdate => paymentdate.PaymentDate < toDate);

            }
            else
           if (toDate == default && fromDate != default)
            {
                query = query.Where(paymentdate => paymentdate.PaymentDate >= fromDate);

            }
            else
            if (toDate != default && fromDate != default)
            {

                query = query.Where(paymentdate => paymentdate.PaymentDate >= fromDate
                && paymentdate.PaymentDate <= toDate);
            }

            return query.ToList();
        }


    }
}
