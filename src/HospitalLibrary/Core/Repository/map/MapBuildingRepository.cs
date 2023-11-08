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
    public class MapBuildingRepository : IMapBuildingRepository
    {
        private readonly HospitalDbContext context;

        public MapBuildingRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public void Create(MapBuilding mapElement)
        {
            context.Add(mapElement);
            context.SaveChanges();
        }

        public void Delete(MapBuilding mapElement)
        {
            context.Remove(mapElement);
            context.SaveChanges();
        }

        public ICollection<MapBuilding> GetAll()
        {
            return context.MapBuildings.Include(x => x.Building).ToList();
        }

        public MapBuilding GetById(int id)
        {
            return context.MapBuildings.Include(x => x.Building).FirstOrDefault(x => x.Id == id);
        }

        public void Update(MapBuilding mapElement)
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
