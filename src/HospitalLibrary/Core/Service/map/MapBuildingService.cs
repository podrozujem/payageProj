using HospitalLibrary.Core.Model.map;
using HospitalLibrary.Core.Repository.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.map
{
    public class MapBuildingService : IMapBuildingService
    {
        private readonly IMapBuildingRepository mapRepository;

        public MapBuildingService(IMapBuildingRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public void Create(MapBuilding mapElement)
        {
            mapRepository.Create(mapElement);
        }

        public void Delete(MapBuilding mapElement)
        {
            mapRepository.Delete(mapElement);
        }

        public ICollection<MapBuilding> GetAll()
        {
            return mapRepository.GetAll();
        }

        public MapBuilding GetById(int id)
        {
            return mapRepository.GetById(id);
        }

        public void Update(MapBuilding mapElement)
        {
            mapRepository.Update(mapElement);
        }
    }
}
