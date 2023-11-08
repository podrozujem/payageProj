using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Payment
    {
        public string Id { get; set; }
        public string HolderName { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }
        public string OrderReference { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Payment(string id, string holderName, double amount, string currency, string cardHolderNumber, int expirationMonth,
        int expirationYear, int cvv, string orderReference, PaymentStatus paymentStatus)
        {
            if (string.IsNullOrWhiteSpace(holderName)) throw new ArgumentException("Invalid Name.");
            Id = id;
            HolderName = holderName;
            Amount = amount;
            Currency = currency;
            CardHolderNumber = cardHolderNumber;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            CVV = cvv;
            OrderReference = orderReference;
            PaymentStatus = paymentStatus;
        }

        public Payment()
        {
        }
    }
}
