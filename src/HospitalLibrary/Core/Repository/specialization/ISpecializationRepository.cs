using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.specialization
{
    public interface ISpecializationRepository
    {
        ICollection<Specialization> GetAll();
        Specialization GetById(int id);
        void Create(Specialization specialization);
        void Update(Specialization specialization);
        void Delete(Specialization specialization);
    }
}
