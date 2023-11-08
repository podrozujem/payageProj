using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto
{
    public class ShowCapturedPayments
    {
        public string Amount { get; set; } 

        public string Currency { get; set; }
        public string CardholderNumber { get; set; }
        public string HolderName { get; set; }
        public string Status { get; set; }

        public ShowCapturedPayments() { }
        public ShowCapturedPayments(string Amount, string Currency, string CardholderNumber, string HolderName, string Status) { 
            this.Amount = Amount;
            this.Currency = Currency;
            this.CardholderNumber = CardholderNumber;
            this.HolderName = HolderName;
            this.Status = Status;
        }
    }
}
