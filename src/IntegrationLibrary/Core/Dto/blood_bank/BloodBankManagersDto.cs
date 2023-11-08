using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Dto.blood_bank
{
    public class BloodBankManagersDto
    {
        public List<BloodBankManagerDto> BloodBankManagers { get; set; }

        public BloodBankManagersDto()
        {
            BloodBankManagers = new List<BloodBankManagerDto>();
        }
    }
}
