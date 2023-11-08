using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.map
{
    public interface IMapRoomService
    {
        ICollection<MapRoom> GetAll();
        MapRoom GetById(int id);
        void Create(MapRoom mapElement);
        void Update(MapRoom mapElement);
        void Delete(MapRoom mapElement);
        /*ICollection<MapRoom> GetMapRoomsByRooms(List<Room> rooms);*/
        ICollection<MapRoom> GetMapRoomsByFloor(int id);
    }
}
