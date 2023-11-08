using AutoMapper;
using IntegrationLibrary.Middleware.Model;
using IntegrationLibrary.Core.Dto.blood_bank;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Service.blood_bank;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

using System;
using System.Net.Http;


namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private readonly IBloodBankService _bloodbankService;
        private readonly IMapper _mapper;

        public BloodBankController(IBloodBankService bloodbankService, IMapper mapper)
        {
            _bloodbankService = bloodbankService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodbankService.GetAll());
        }

        [HttpGet("getAllWithManagerEmail")]
        public async Task<ActionResult> GetAllWithManagerEmail()
        {
            return Ok(await _bloodbankService.GetAllWithManagerEmail());
        }

        [HttpGet("{id}")]
        public ActionResult GetByid(int id)
        {
            var bloodbank = _bloodbankService.GetByid(id);
            if (bloodbank == null)
            {
                return NotFound();
            }

            return Ok(bloodbank);
        }

        [HttpGet("GetByUserId/{userId}")]
        public ActionResult GetByUserId(int userId)
        {
            var bloodbank = _bloodbankService.GetByUserId(userId);
            if (bloodbank == null)
            {
                return NotFound();
            }

            return Ok(bloodbank);
        }

        [HttpPost]
        public ActionResult Create(BloodBank bloodbank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bloodbankService.Create(bloodbank);
            return CreatedAtAction("GetByid", new { id = bloodbank.Id }, bloodbank);
        }

        [HttpPut("UpdateByManager/{id}")]
        public ActionResult UpdateByManager(int id, BloodBankDto bloodbankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                BloodBank oldBloodBank = _bloodbankService.GetByid(id);
                if (oldBloodBank == null) return NotFound();

                oldBloodBank.CompanyName = bloodbankDto.CompanyName;
                oldBloodBank.ServerAddress = bloodbankDto.ServerAddress;
                _bloodbankService.Update(oldBloodBank);
                return Ok(oldBloodBank);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bloodbank = _bloodbankService.GetByid(id);
            if (bloodbank == null)
            {
                return NotFound();
            }
            try
            {
                Task task = _bloodbankService.Delete(bloodbank);
                task.Wait();
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public ActionResult Register(BloodBankDto bloodbankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bloodBank = _mapper.Map<BloodBank>(bloodbankDto);
            _bloodbankService.Create(bloodBank);
            return Ok(bloodBank);
        }
        [HttpPost("updateApiKeyForBloodBank")]
        public ActionResult UpdateApiKeyForBloodBank(UpdateApiKeyForBloodBankDto bloodBankDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bloodBank = _bloodbankService.GetByUserId(bloodBankDto.UserId);
            if(bloodBank == null) return NotFound();
            bloodBank.ApiKey = bloodBankDto.ApiKey;
            Task<HttpStatusCode> result = _bloodbankService.ValidateApiKey(bloodBankDto.ApiKey, bloodBankDto.ServerAddress);
            if (result.Result == HttpStatusCode.Forbidden) throw new ForbiddenAccessException();
            _bloodbankService.Update(bloodBank);
            return Ok();
        }

        [HttpGet("checkBank/{bankId}")]
        public ActionResult checkBloodSupplies(int bankId, int amount, string bloodType)
        {
            Task<string> result = _bloodbankService.checkBloodSupplies(amount, bloodType, bankId);
            result.Wait();
            MessageDto m = new MessageDto(result.Result);
            return Ok(m);
            
        }
    }
}