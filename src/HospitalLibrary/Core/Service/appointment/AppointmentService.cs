using HospitalLibrary.Core.Dto.appointment;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public void Create(Appointment appointment)
        {
            _appointmentRepository.Create(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
           return _appointmentRepository.GetAll();
        }

        public List<AppointmentDTO> GetAllAppointmentDTOsByDoctorId(string doctorId)
        {
            return _appointmentRepository.GetAllAppointmentDTOsByDoctorId(doctorId);
        }

        public Appointment GetById(string id)
        {
            return _appointmentRepository.GetById(id);
        }

        public void Update(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }
    }
}
