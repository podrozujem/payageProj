using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.floor
{
    public class FloorRepository : IFloorRepository
    {
        private readonly HospitalDbContext context;

        public FloorRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public void Create(Floor floor)
        {
            context.Floors.Add(floor);
            context.SaveChanges();
        }

        public void Delete(Floor floor)
        {
            context.Floors.Remove(floor);
            context.SaveChanges();
        }

        public ICollection<Floor> GetAll()
        {
            return context.Floors.Include(x => x.Building).ToList();
        }

        public Floor GetById(int id)
        {
            return context.Floors.Include(x => x.Building).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Floor floor)
        {
            context.Entry(floor).State = EntityState.Modified;

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
