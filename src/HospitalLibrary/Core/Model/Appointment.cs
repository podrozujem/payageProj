using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public string AppointmentId { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public Room Room { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public AppointmentType AppointmentType { get; set; }

        
    }
}
