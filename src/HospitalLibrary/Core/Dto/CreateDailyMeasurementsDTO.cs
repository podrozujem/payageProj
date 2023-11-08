using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto
{
    public class CreateDailyMeasurementsDTO
    {
        public string DailyMeasurementsId { get; set; }
        public DateTime DateTimeOfMeasurements { get; set; }
        public int DoctorId { get; set; }

        public  int PatientId { get; set; }

        public float BloodPreasure { get; set; }

        public float BloodSugar { get; set; }

        public float FatPercentage { get; set; }

        public float Weight { get; set; }

        public string MenstrualCycle { get; set; }
    }
}
