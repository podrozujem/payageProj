using IntegrationLibrary.Core.Model;
using System.Collections.Generic;

namespace IntegrationLibrary.Core.Repository.blood_bank
{
    public interface IBloodBankRepository
    {
        IEnumerable<BloodBank> GetAll();
        BloodBank GetByid(int id);
        void Create(BloodBank bloodbank);
        void Update(BloodBank bloodbank);
        void Delete(BloodBank bloodbank);
        BloodBank GetByUserId(int userId);
    }
}