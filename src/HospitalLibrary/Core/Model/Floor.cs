using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public Building Building { get; set; }
    }
}
