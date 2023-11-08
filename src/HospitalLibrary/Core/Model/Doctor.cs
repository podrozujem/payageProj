using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Model
{
    public class Doctor : User
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Specialization Specialization { get; set; }

        //public string Specialization { get; set; }

    }
}
