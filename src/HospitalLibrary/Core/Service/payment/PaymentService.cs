using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository; 

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public void Create(Payment paymentDTO)
        {
            _paymentRepository.Create(paymentDTO); 
        }

        public IEnumerable<Payment> GetAll()
        {
            return _paymentRepository.GetAll(); 
        }

        public IEnumerable<Payment> GetAllCaptured(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Payment GetById(string id)
        {
            return _paymentRepository.GetById(id); 
        }

        public List<Payment> GetCaptured()
        {
            IEnumerable<Payment> lista = GetAll();

            List<Payment> capturedPayments = new List<Payment>();  
            foreach (Payment payment in lista)
            {
                if (payment.PaymentStatus.Equals(PaymentStatus.CAPTURED)) {
                    capturedPayments.Add(payment); 
                }
            }

            return capturedPayments;
        }

        public void Update(Payment paymentDTO)
        {
            _paymentRepository.Update(paymentDTO); 
        }

        public Payment UpdateStatusVoid(string id)
        {
            Payment payment = _paymentRepository.GetById(id);
            payment.PaymentStatus = PaymentStatus.VOIDED;

            _paymentRepository.Update(payment);
            return payment;
        }

        public Payment UpdateStatusCaptured(string id)
        {
            Payment payment = _paymentRepository.GetById(id);
            payment.PaymentStatus = PaymentStatus.CAPTURED;
            _paymentRepository.Update(payment);
            return payment;
        }
    }
}
