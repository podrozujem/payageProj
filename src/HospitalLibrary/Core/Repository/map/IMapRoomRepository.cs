using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.map
{
    public interface IMapRoomRepository
    {
        ICollection<MapRoom> GetAll();
        MapRoom GetById(int id);
        void Create(MapRoom mapElement);
        void Update(MapRoom mapElement);
        void Delete(MapRoom mapElement);
    }
}
