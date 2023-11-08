using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto.appointment
{
    public class AppointmentDTO
    {
        public string AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientName { get; set; }
        public string RoomNumber { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string AppointmentType { get; set; }

        public AppointmentDTO(Appointment appointment)
        {
            this.AppointmentId = appointment.AppointmentId;
            this.DoctorId = appointment.Doctor.Id.ToString();
            this.PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName;
            this.RoomNumber = appointment.Room.Number;
            this.Date = appointment.Date.ToString("d");
            this.StartTime = appointment.StartTime.ToString("t");
            this.EndTime = appointment.EndTime.ToString("t");
            if (appointment.AppointmentType.Equals("EXAMINATION"))
            {
                this.AppointmentType = "EXAMINATION";
            }
            else
            {
                this.AppointmentType = "OPERATION";
            }      
            
        }

    }
}
