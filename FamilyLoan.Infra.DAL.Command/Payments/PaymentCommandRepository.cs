using AutoMapper;
using AutoMapper.QueryableExtensions;
using FamilyLoan.Core.Contracts.Payments;
using FamilyLoan.Core.Domains.Payments;
using FamilyLoan.Core.Domains.Payments.DTO;
using FamilyLoan.Infra.DAL.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FamilyLoan.Infra.DAL.Command.Payments
{
    public class PaymentCommandRepository : IPaymentCommandRepository
    {
        private readonly FamilyLoanCommandDbContext _dbcontext;
        private readonly IMapper _mapper;

        public PaymentCommandRepository(IMapper mapper, FamilyLoanCommandDbContext dbcontext)
        {
            _mapper = mapper;
            _dbcontext = dbcontext;
        }

        public PaymentDTO AddPayment(PaymentDTO PaymentDTO)
        {
            var payment = _mapper.Map<Payment>(PaymentDTO);
            _dbcontext.Payments.Add(payment);
            _dbcontext.SaveChanges();
            return PaymentDTO;
        }

       


        public PaymentDTO GetById(int id)
        {
            var payment = _dbcontext.Payments.AsNoTracking().SingleOrDefault(paymentid => paymentid.Id == id);
            PaymentDTO paymentDTO= _mapper.Map<PaymentDTO>(payment);
            return paymentDTO;

        }
       
        public void DeletePayment(int PaymentId)
        {
            var paymentDelete = _dbcontext.Payments.SingleOrDefault(paymentid => paymentid.Id == PaymentId);
            paymentDelete.IsDeleted = true;
             _dbcontext.SaveChanges();
            
        }

        public PaymentDTO UpdatePayment(PaymentDTO PaymentDTO)
        {
            var Payment = _dbcontext.Payments
                    .ProjectTo<PaymentDTO>(_mapper.ConfigurationProvider)
                     .SingleOrDefault(paymentid => paymentid.Id == PaymentDTO.Id);
            if (Payment != null)
            {
                _mapper.Map(PaymentDTO, Payment);

                _dbcontext.SaveChanges();
                return Payment;
            }
            else
            {
                return null;

            }

        }


    }
}
