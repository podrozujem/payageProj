using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.user;
using HospitalLibrary.Core.SecurePassword;
using HospitalLibrary.Core.Service.user;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public void RegisterBloodBankManager(User user)
        {
            user.Type = UserType.BLOOD_BANK_MANAGER;
            user.RequirePasswordChange = true;
            user.Password = Guid.NewGuid().ToString();
            //TODO validacija da li je user.email vec postojeci
            throw new Exception("Error sending email.");
            
        }

        public User Login(User user)
        {
            var userByEmail = _userRepository.GetByEmail(user.Email);
            if (userByEmail != null)
            {
                if (userByEmail.Password != user.Password) userByEmail = null;
            }
            return userByEmail;
        }

        public IEnumerable<User> GetAllBloodBankManagers()
        {
            return GetAll().Where(u => u.Type == UserType.BLOOD_BANK_MANAGER);
        
        }
        
        public string SecurePassword(string password)
        {
            var hash = SecurePasswordHasher.Hash(password);
            return hash;
        }
    }
}