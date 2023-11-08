using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.manager
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public IEnumerable<Manager> GetAll()
        {
            return _managerRepository.GetAll();
        }

        public Manager GetById(int id)
        {
            return _managerRepository.GetById(id);
        }

        public void Create(Manager manager)
        {
            _managerRepository.Create(manager);
        }

        public void Update(Manager manager)
        {
            _managerRepository.Update(manager);
        }

        public void Delete(Manager manager)
        {
            _managerRepository.Delete(manager);
        }
    }
}
