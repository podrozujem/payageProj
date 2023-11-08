using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.building
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly HospitalDbContext context;

        public BuildingRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public void Create(Building building)
        {
            context.Buildings.Add(building);
            context.SaveChanges();
        }

        public void Delete(Building building)
        {
            context.Buildings.Remove(building);
            context.SaveChanges();
        }

        public ICollection<Building> GetAll()
        {
            return context.Buildings.ToList();
        }

        public Building GetById(int id)
        {
            return context.Buildings.Find(id);
        }

        public void Update(Building building)
        {
            context.Entry(building).State = EntityState.Modified;

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
