using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.room;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Service.room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public void Create(Room room)
        {
            _roomRepository.Create(room);
        }

        public void Update(Room room)
        {
            _roomRepository.Update(room);
        }

        public void Delete(Room room)
        {
            _roomRepository.Delete(room);
        }

        public IEnumerable<Room> GetFloorsByBuilding(int id)
        {
            var rooms = _roomRepository.GetAll();
            var roomsByFloor = new List<Room>();

            foreach (var room in rooms)
            {
                if (room.Floor.Id == id)
                {
                    roomsByFloor.Add(room);
                }
            }
            return roomsByFloor;
        }
    }
}
