using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.dailyMeasurements;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.dailyMeasurement
{
    public class DailyMeasurementsRepository: IDailyMeasurementsRepository
    {

        private readonly HospitalDbContext _context;
        private readonly Random _random = new Random();

        public DailyMeasurementsRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DailyMeasurements> GetAll()
        {
            return _context.dailyMeasurementsList.Include(x => x.Doctor).Include(x => x.Patient).ToList();
        }

        public DailyMeasurements GetById(string id)
        {
            return _context.dailyMeasurementsList.Find(id);
        }

        public void Create(DailyMeasurements dailyMeasurements)
        {
            _context.dailyMeasurementsList.Add(dailyMeasurements);
            _context.SaveChanges();
        }

        public void Update(DailyMeasurements dailyMeasurements)
        {
            _context.Entry(dailyMeasurements).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(DailyMeasurements dailyMeasurements)
        {
            _context.dailyMeasurementsList.Remove(dailyMeasurements);
            _context.SaveChanges();
        }

    }
}
