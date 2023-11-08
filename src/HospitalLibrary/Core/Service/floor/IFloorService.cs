using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.floor
{
    public interface IFloorService
    {
        ICollection<Floor> GetAll();
        Floor GetById(int id);
        void Create(Floor floor);
        void Update(Floor floor);
        void Delete(Floor floor);
        ICollection<Floor> GetFloorsByBuilding(int id);
    }
}
