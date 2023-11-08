using HospitalLibrary.Core.Model.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.map
{
    public interface IMapBuildingRepository
    {
        ICollection<MapBuilding> GetAll();
        MapBuilding GetById(int id);
        void Create(MapBuilding mapElement);
        void Update(MapBuilding mapElement);
        void Delete(MapBuilding mapElement);
    }
}
