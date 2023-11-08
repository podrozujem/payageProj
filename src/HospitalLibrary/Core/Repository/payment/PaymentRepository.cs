using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly HospitalDbContext _context;

        public PaymentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public Payment Create(Payment payment)
        {
            _context.payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.payments.ToList(); 
        }

        public IEnumerable<Payment> GetAllCaptured()
        {
            List<Payment> result = new List<Payment>();
            foreach (var payment in GetAll())
            {
                if (payment.PaymentStatus.Equals(PaymentStatus.CAPTURED))
                {
                    result.Add(payment);
                }
            }

            return result;
        }

        public Payment GetById(string id)
        {
            return _context.payments.Find(id);
        }

        public Payment Update(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return payment;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
