using HospitalLibrary.Core.Model.map;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HospitalLibrary.Core.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Number { get; set; }
        public Building Building { get; set; }
        public Floor Floor { get; set; }
    }
}
