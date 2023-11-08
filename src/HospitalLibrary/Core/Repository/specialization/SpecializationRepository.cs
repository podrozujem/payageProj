using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.specialization
{
    public class SpecializationRepository
    {
        private readonly HospitalDbContext _context;

        public SpecializationRepository()
        {
        }

        public SpecializationRepository(HospitalDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            _context.SaveChanges();
        }

        public void Delete(Specialization specialization)
        {
            _context.Specializations.Remove(specialization);
            _context.SaveChanges();
        }

        //public ICollection<Specialization> GetAll()
        //{
        //    return context.Specializations.Include(x => x.Doctor).ToList();
        //}

        //public Specialization GetById(int id)
        //{
        //    return context.Specializations.Include(x => x.Doctor).FirstOrDefault(x => x.Id == id);
        //}

        public IEnumerable<Specialization> GetAll()
        {
            return _context.Specializations.ToList();
        }

        public Specialization GetById(string id)
        {
            return _context.Specializations.Find(id);
        }

        public void Update(Specialization specialization)
        {
            _context.Entry(specialization).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
