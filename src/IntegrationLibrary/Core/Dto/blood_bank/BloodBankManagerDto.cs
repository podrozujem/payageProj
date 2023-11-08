using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.blood_bank
{
    public class BloodBankManagerDto
    {
        public int BloodBankId { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string CompanyName { get; set; }
        public string ServerAddress { get; set; }
    }
}
