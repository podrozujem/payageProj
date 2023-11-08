using System;
using HospitalLibrary.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.manager
{
    public interface IManagerService
    {
        IEnumerable<Manager> GetAll();
        Manager GetById(int id);
        void Create(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
