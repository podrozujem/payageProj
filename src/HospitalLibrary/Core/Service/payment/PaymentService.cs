using HospitalLibrary.Core.Dto;
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

        public IEnumerable<ShowCapturedPayments> GetAllCaptured(int page, int pageSize)
        {
            List<ShowCapturedPayments> capturedList = GetCaptured();
            var totalCount = capturedList.Count;
            var totalPages = (int) Math.Ceiling((decimal) totalCount / pageSize);
            var paymentsPerPage = capturedList.Skip(page).Take(pageSize).ToList();
            
            return paymentsPerPage;
        }

        public Payment GetById(string id)
        {
            return _paymentRepository.GetById(id); 
        }

        public List<ShowCapturedPayments> GetCaptured()
        {
            IEnumerable<Payment> lista = GetAll();

            List<ShowCapturedPayments> capturedPayments = new List<ShowCapturedPayments>();  
            foreach (Payment payment in lista)
            {
                if (payment.PaymentStatus.Equals(PaymentStatus.CAPTURED)) {
                    ShowCapturedPayments showCapturedPayment = new ShowCapturedPayments();
                    showCapturedPayment.Amount = payment.Amount.ToString(); 
                    showCapturedPayment.Currency = payment.Currency;
                    showCapturedPayment.HolderName = payment.HolderName;
                    showCapturedPayment.Status = "Captured";
                    var firstThree = payment.CardHolderNumber.Substring(0, 3); 
                    var lastThree = payment.CardHolderNumber.Substring(payment.CardHolderNumber.Length - 3);
                    showCapturedPayment.CardholderNumber = firstThree + "*******" + lastThree;

                    capturedPayments.Add(showCapturedPayment); 
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
