using HospitalLibrary.Middleware.Model;
using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.patient;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("/check-login-credentials")]
        public Patient GetLoginPermission(LoginCredentials loginCredentials)
        {
            if (loginCredentials.Email.Length == 0 || loginCredentials.Password.Length == 0)
                throw new EmptyFieldExistedException();
            if(!MailAddress.TryCreate(loginCredentials.Email, out var mailAddress))
                throw new IncorrectEmailFormatException();    
            Patient patient = _patientService.CheckLoginCredentials(loginCredentials.Email, loginCredentials.Password);
            if(patient == null) 
                throw new NotExistingUserAccountException();
            return patient;
        }

       
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        
        [HttpPut("{id}")]
        public ActionResult Update(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            try
            {
                _patientService.Update(patient);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(patient);
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var room = _patientService.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            _patientService.Delete(room);
            return NoContent();
        }
    }
}
