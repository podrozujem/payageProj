using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.building
{
    public interface IBuildingRepository
    {
        ICollection<Building> GetAll();
        Building GetById(int id);
        void Create(Building building);
        void Update(Building building);
        void Delete(Building building);
    }
}
