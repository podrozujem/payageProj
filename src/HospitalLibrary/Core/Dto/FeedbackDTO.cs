using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Dto
{
    public class FeedbackDTO
    {
        public  int Id { get; set; }
        public string Text { get; set; }
        public string PatientName { get; set; }
        public string DateOfCreation { get; set; }
        public bool IsPublic { get; set; }
        public bool IsApproved { get; set; }

        public FeedbackDTO(Feedback feedback)
        {
            this.Id = feedback.Id;
            this.Text = feedback.Text;
            this.DateOfCreation = feedback.DateOfCreation.ToString("yyyy-MM-dd");
            this.IsPublic = feedback.IsPublic;
            this.IsApproved = feedback.IsApproved;
        }

    }
}
