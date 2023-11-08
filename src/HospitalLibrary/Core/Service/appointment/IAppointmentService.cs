using HospitalLibrary.Core.Dto.appointment;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.appointment
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        List<AppointmentDTO> GetAllAppointmentDTOsByDoctorId(string id);
        Appointment GetById(string id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
    }
}
