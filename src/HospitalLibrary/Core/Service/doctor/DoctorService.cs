using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.doctor
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }
        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }
        public void Create(Doctor doctor)
        {
            _doctorRepository.Create(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctorRepository.Delete(doctor);
        }
        public void Update(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
        }
        public Doctor CheckLoginCredentials(string email, string password)
        {
            return _doctorRepository.CheckLoginCredentials(email, password);
        }
    }
}
