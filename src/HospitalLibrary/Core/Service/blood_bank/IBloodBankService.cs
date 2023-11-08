using HospitalLibrary.Dto.blood_bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.blood_bank
{
    public interface IBloodBankService
    {
        Task RegisterBloodBank(BloodBankDto bloodBankDto);
    }
}
