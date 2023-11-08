using HospitalLibrary.Dto.blood_bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalLibrary.Core.Service.blood_bank
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BloodBankService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task RegisterBloodBank(BloodBankDto bloodBankDto)
        {
            var httpClient = _httpClientFactory.CreateClient("IntegrationClient");
            var bloodBankDtoJson = new StringContent(JsonSerializer.Serialize(bloodBankDto), Encoding.UTF8, Application.Json);
            using var httpResponseMessage = await httpClient.PostAsync("/api/BloodBank/register", bloodBankDtoJson);
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
