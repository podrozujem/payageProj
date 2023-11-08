using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.map;
using HospitalLibrary.Core.Repository.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.map
{
    public class MapRoomService : IMapRoomService
    {
        private readonly IMapRoomRepository mapRepository;

        public MapRoomService(IMapRoomRepository mapRepository)
        {
            this.mapRepository = mapRepository;
        }
        public void Create(MapRoom mapElement)
        {
            mapRepository.Create(mapElement);
        }

        public void Delete(MapRoom mapElement)
        {
            mapRepository.Delete(mapElement);
        }

        public ICollection<MapRoom> GetAll()
        {
            return mapRepository.GetAll();
        }

        public MapRoom GetById(int id)
        {
            return mapRepository.GetById(id);
        }

        /*public ICollection<MapRoom> GetMapRoomsByRooms(List<Room> rooms)
        {
            var mapRooms = mapRepository.GetAll();
            var mapRoomsByRooms = new List<MapRoom>();
            foreach (var mapRoom in mapRooms)
            {
                foreach (var room in rooms)
                {
                    if (room.Id == mapRoom.Room.Id)
                    {
                        mapRoomsByRooms.Add(mapRoom);
                        break;
                    }
                }
            }
            return mapRoomsByRooms;
        }*/

        public ICollection<MapRoom> GetMapRoomsByFloor(int id)
        {
            var mapRooms = mapRepository.GetAll();
            var mapRoomsByFloor = new List<MapRoom>();

            foreach (var mapRoom in mapRooms)
            {
                if (mapRoom.Room.Floor.Id == id) 
                {
                    mapRoomsByFloor.Add(mapRoom);
                }
            }
            return mapRoomsByFloor;
        }

        public void Update(MapRoom mapElement)
        {
            mapRepository.Update(mapElement);
        }
    }
}
