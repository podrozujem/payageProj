using AutoMapper;
using HospitalLibrary.Dto.blood_bank;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.user;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Core.Service.blood_bank;
using HospitalLibrary.Core.Dto.user;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,IBloodBankService bloodBankService, IMapper mapper)
        {
            _userService = userService;
            _bloodBankService = bloodBankService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("getAllUserEmails")]
        public ActionResult GetAllUserEmails()
        {
            var users =_userService.GetAllBloodBankManagers();
            var userEmailDtos = new UserEmailDtos();
            foreach(User user in users)
            {
                UserEmailDto u = _mapper.Map<UserEmailDto>(user);
                userEmailDtos.UserEmails.Add(u);
            }

            return Ok(userEmailDtos);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.Create(user);
            return CreatedAtAction("GetById", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, User user)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userService.Update(user);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.Delete(user);
            return NoContent();
        }

        [HttpPost("registerBloodBank")]
        public ActionResult RegisterBloodBank(BloodBankRegistrationDto bloodBankRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(bloodBankRegistrationDto);
            try
            {
                _userService.RegisterBloodBankManager(user);
            }
            catch(Exception e)
            {
                // TODO registracija blood bank managera neuspesna
                return BadRequest(e.Message);
            }

            try
            {
                var bloodBankDto = _mapper.Map<BloodBankDto>(bloodBankRegistrationDto);
                bloodBankDto.ApiKey = "";
                bloodBankDto.UserId = user.Id;
                _bloodBankService.RegisterBloodBank(bloodBankDto);

                return Ok(bloodBankDto);
            }
            catch(Exception e)
            {
                //TODO IntegrationAPI offline obrada greske
                return BadRequest("IntegrationAPI is unreachable. Could be offline.");
            }

        }
        [HttpPost("dummyLogin")]
        public ActionResult Login(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _mapper.Map<User>(userDto);
            user = _userService.Login(user);
            if (user == null) return BadRequest(userDto);
            return Ok(user);
        }
        [HttpPut("changePassword")]
        public ActionResult ChangePassword(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                user.RequirePasswordChange = false;
                var securedPassword = _userService.SecurePassword(user.Password);
                user.Password = securedPassword;
                _userService.Update(user);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(user);
        }

    }
}