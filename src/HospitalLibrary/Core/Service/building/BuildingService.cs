using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.building;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.building
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }
        public void Create(Building building)
        {
            buildingRepository.Create(building);
        }

        public void Delete(Building building)
        {
            buildingRepository.Delete(building);
        }

        public ICollection<Building> GetAll()
        {
            return buildingRepository.GetAll();
        }

        public Building GetById(int id)
        {
            return buildingRepository.GetById(id);
        }

        public void Update(Building building)
        {
            buildingRepository.Update(building);
        }
    }
}
