using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.floor
{
    public interface IFloorRepository
    {
        ICollection<Floor> GetAll();
        Floor GetById(int id);
        void Create(Floor floor);
        void Update(Floor floor);
        void Delete(Floor floor);
    }
}
