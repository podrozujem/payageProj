using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.manager
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> GetAll();
        Manager GetById(int id);
        void Create(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
