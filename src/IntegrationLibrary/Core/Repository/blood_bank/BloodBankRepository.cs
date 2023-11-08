using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace IntegrationLibrary.Core.Repository.blood_bank
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodBankRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _context.BloodBanks.ToList();
        }

        public BloodBank GetByid(int id)
        {
            return _context.BloodBanks.Find(id);
        }

        public BloodBank GetByUserId(int userId)
        {
            return (from bloodBank in _context.BloodBanks
                   where bloodBank.UserId.Equals(userId)
                   select bloodBank).SingleOrDefault();
        }

        public void Create(BloodBank bloodbank)
        {
            _context.BloodBanks.Add(bloodbank);
            _context.SaveChanges();
        }

        public void Update(BloodBank bloodbank)
        {
            _context.Entry(bloodbank).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(BloodBank bloodbank)
        {
            _context.BloodBanks.Remove(bloodbank);
            _context.SaveChanges();
        }
    }
}