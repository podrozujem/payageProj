using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public void Create(Patient patient)
        {
            _patientRepository.Create(patient);
        }

        public void Update(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }

        public Patient CheckLoginCredentials(string email, string password)
        {
            return _patientRepository.CheckLoginCredentials(email, password);
        }
    }
}
