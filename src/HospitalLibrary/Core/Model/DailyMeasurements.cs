using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class DailyMeasurements
    {
        public string DailyMeasurementsId { get; set; }

        public DateTime DateTimeOfMeasurements { get; set; }
        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        //public Appointment Appointment { get; set; } // pitati asistenta

        public float BloodPreasure { get; set; }

        public float BloodSugar { get; set; }

        public float FatPercentage { get; set; }

        public float Weight { get; set; }

        public DateTime MenstrualCycle { get; set; }


    }
}
