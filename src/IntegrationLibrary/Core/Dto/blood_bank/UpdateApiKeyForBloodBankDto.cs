using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.blood_bank
{
    public class UpdateApiKeyForBloodBankDto
    {
        public int UserId { get; set; }
        public string ApiKey { get; set; }
        public string ServerAddress { get; set; }
    }
}
