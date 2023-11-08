using HospitalLibrary.Middleware.Model;
using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.doctor;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        [HttpPost("/check-login-credentials-doctor")]
        public Doctor GetLoginPermission(LoginCredentials loginCredentials)
        {
            if (loginCredentials.Email.Length == 0 || loginCredentials.Password.Length == 0)
                throw new EmptyFieldExistedException();
            if (!MailAddress.TryCreate(loginCredentials.Email, out var mailAddress))
                throw new IncorrectEmailFormatException();
            Doctor doctor = _doctorService.CheckLoginCredentials(loginCredentials.Email, loginCredentials.Password);
            if (doctor == null)
                throw new NotExistingUserAccountException();
            return doctor;
        }
    }
}
