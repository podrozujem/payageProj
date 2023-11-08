﻿using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.patient
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        Patient CheckLoginCredentials(string email, string password);
    }
}
