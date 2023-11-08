using IntegrationLibrary.Core.Dto.blood_bank;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.blood_bank;
using IntegrationLibrary.Middleware.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Dto.user;
using System.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.blood_bank
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository _bloodbankRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public BloodBankService(IBloodBankRepository bloodbankRepository, IHttpClientFactory httpClientFactory)
        {
            _bloodbankRepository = bloodbankRepository;
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _bloodbankRepository.GetAll();
        }

        public BloodBank GetByid(int id)
        {
            return _bloodbankRepository.GetByid(id);
        }

        public BloodBank GetByUserId(int userId)
        {
            return _bloodbankRepository.GetByUserId(userId);
        }

        public void Create(BloodBank bloodBank)
        {
            _bloodbankRepository.Create(bloodBank);
        }

        public void Update(BloodBank bloodBank)
        {
            _bloodbankRepository.Update(bloodBank);
        }

        public async Task Delete(BloodBank bloodBank)
        {
            var httpClient = _httpClientFactory.CreateClient("HospitalClient");
            using var httpResponseMessage = await httpClient.DeleteAsync("/api/User/"+ bloodBank.UserId);
            if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.NoContent) throw new UnableDeletingUserAccountException();
            _bloodbankRepository.Delete(bloodBank);
        }

        public async Task<BloodBankManagersDto> GetAllWithManagerEmail()
        {
            var bloodBankManagersDto = new BloodBankManagersDto();

            var BloodBanks = GetAll();

            var httpClient = _httpClientFactory.CreateClient("HospitalClient");
            using var httpResponseMessage = await httpClient.GetAsync("/api/User/getAllUserEmails");
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            UserEmailDtos userEmailDtos = JsonSerializer.Deserialize<UserEmailDtos>(responseBody);

            foreach (var bloodBank in BloodBanks)
            {
                var bloodBankManagerDto = new BloodBankManagerDto();

                bloodBankManagerDto.BloodBankId = bloodBank.Id;
                bloodBankManagerDto.UserId = bloodBank.UserId;
                bloodBankManagerDto.CompanyName = bloodBank.CompanyName;
                bloodBankManagerDto.ServerAddress = bloodBank.ServerAddress;
                bloodBankManagerDto.UserEmail = userEmailDtos.userEmails.Where(u => u.id == bloodBank.UserId).SingleOrDefault().email;
                bloodBankManagerDto.UserId = bloodBank.UserId;

                bloodBankManagersDto.BloodBankManagers.Add(bloodBankManagerDto);
            }


            return bloodBankManagersDto;
        }
        public async Task<HttpStatusCode> ValidateApiKey(string apiKey, string url)
        {
            var httpClient = _httpClientFactory.CreateClient("IntegrationClient");
            httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
            try
            {
                using var httpResponseMessage = await httpClient.GetAsync(url + "/api/api-key/validate");
                HttpStatusCode httpStatusCode = httpResponseMessage.StatusCode;
                return httpStatusCode;
            }
            catch 
            {
                throw new ServiceUnavailableException();
            }
        }

        public async Task<string> checkBloodSupplies(int amount, string bloodType, int id) 
        {
            var httpClient = _httpClientFactory.CreateClient("IntegrationClient1");
            BloodBank bb = GetByid(id);
            httpClient.DefaultRequestHeaders.Add("Authorization", bb.ApiKey);
            using var httpResponseMessage = await httpClient.GetAsync(bb.ServerAddress + "/api/blood-sample?amount="+amount+"&bloodType=" + bloodType);
            Task<string> message = httpResponseMessage.Content.ReadAsStringAsync();
      
            return httpResponseMessage.Content.ReadAsStringAsync().Result;

        }
    }
}