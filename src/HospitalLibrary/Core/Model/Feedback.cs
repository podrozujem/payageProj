using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsPublic { get; set; }  
        public bool IsApproved { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int patientId { get; set; }
    }
}
