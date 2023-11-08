using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto
{
    public class AppointmentCreationDTO
    {
        public int doctorId { get; set; }
        public int patientId { get; set; }
        public int roomId { get; set; }
        public DateTime Date { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public AppointmentType AppointmentType { get; set; }
    }
}
