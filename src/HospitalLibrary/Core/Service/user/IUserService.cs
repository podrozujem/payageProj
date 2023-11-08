using HospitalLibrary.Core.Dto.user;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service.user
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        void RegisterBloodBankManager(User user);
        User Login(User user);
        IEnumerable<User> GetAllBloodBankManagers();
        string SecurePassword(string password);
    }
}