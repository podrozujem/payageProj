using HospitalLibrary.Core.Model.map;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.map
{
    public class MapRoomRepository : IMapRoomRepository
    {
        private readonly HospitalDbContext context;

        public MapRoomRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public void Create(MapRoom mapElement)
        {
            context.Add(mapElement);
            context.SaveChanges();
        }

        public void Delete(MapRoom mapElement)
        {
            context.Remove(mapElement);
            context.SaveChanges();
        }

        public ICollection<MapRoom> GetAll()
        {
            return context.MapRooms.Include(x => x.Room).ThenInclude(x => x.Floor).ThenInclude(x => x.Building).ToList();
        }

        public MapRoom GetById(int id)
        {
            return context.MapRooms.Include(x => x.Room).ThenInclude(x => x.Floor).ThenInclude(x => x.Building).FirstOrDefault(x => x.Id == id);
        }

        public void Update(MapRoom mapElement)
        {
            context.Entry(mapElement).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
