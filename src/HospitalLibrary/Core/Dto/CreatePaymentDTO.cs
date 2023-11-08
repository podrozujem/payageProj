using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto
{
    public class CreatePaymentDTO
    {
        public string HolderName { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string CardHolderNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVV { get; set; }
        public string OrderReference { get; set; }

        public CreatePaymentDTO(string HolderName, double Amount, string Currency, string CardHolderNumber, 
            int ExpirationMonth, int ExpirationYear, int CVV, string OrderReference) {
            
            this.HolderName = HolderName;
            this.Amount = Amount;
            this.Currency = Currency;
            this.CardHolderNumber = CardHolderNumber;
            this.ExpirationMonth = ExpirationMonth;
            this.ExpirationYear = ExpirationYear;
            this.CVV = CVV;
            this.OrderReference = OrderReference;
        }
    }
}
