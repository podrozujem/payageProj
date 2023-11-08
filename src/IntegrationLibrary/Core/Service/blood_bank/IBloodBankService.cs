using IntegrationLibrary.Core.Dto.blood_bank;
using IntegrationLibrary.Core.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.blood_bank
{
    public interface IBloodBankService
    {
        IEnumerable<BloodBank> GetAll();
        BloodBank GetByid(int id);
        void Create(BloodBank bloodbank);
        void Update(BloodBank bloodbank);
        Task Delete(BloodBank bloodbank);
        BloodBank GetByUserId(int userId);
        Task<BloodBankManagersDto> GetAllWithManagerEmail();
        Task<HttpStatusCode> ValidateApiKey(string apiKey, string url);
        Task<string> checkBloodSupplies(int amount, string bloodType, int id);
    }
}