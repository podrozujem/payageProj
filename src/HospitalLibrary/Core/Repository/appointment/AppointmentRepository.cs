using HospitalLibrary.Core.Dto.appointment;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository.appointment
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public void Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient).Include(x => x.Room).ToList();
        }

        public List<AppointmentDTO> GetAllAppointmentDTOsByDoctorId(string doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
            {
                if ((appointment.Doctor.Id.ToString()).Equals(doctorId))
                    appointments.Add(appointment);
            }
            return GetAppointmentDTOs(appointments);
        }
        public List<AppointmentDTO> GetAppointmentDTOs(List<Appointment> appointments)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO(appointment);
                appointmentDTOs.Add(appointmentDTO);
            }
            return appointmentDTOs;
        }
        public Appointment GetById(string id)
        {
            return _context.Appointments.Find(id);
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;

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
