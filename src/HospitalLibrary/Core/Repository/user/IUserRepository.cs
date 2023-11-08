using HospitalLibrary.Core.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository.user
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}