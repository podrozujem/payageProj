using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.floor
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            this.floorRepository = floorRepository;
        }
        public void Create(Floor floor)
        {
            floorRepository.Create(floor);
        }

        public void Delete(Floor floor)
        {
            floorRepository.Delete(floor);
        }

        public ICollection<Floor> GetAll()
        {
            return floorRepository.GetAll();
        }

        public Floor GetById(int id)
        {
            return floorRepository.GetById(id);
        }

        public ICollection<Floor> GetFloorsByBuilding(int id)
        {
            var floors = floorRepository.GetAll();
            var floorsByBuilding = new List<Floor>();

            foreach (var floor in floors)
            {
                if (floor.Building.Id == id)
                {
                    floorsByBuilding.Add(floor);
                }
            }
            return floorsByBuilding;
        }

        public void Update(Floor floor)
        {
            floorRepository.Update(floor);
        }
    }
}
