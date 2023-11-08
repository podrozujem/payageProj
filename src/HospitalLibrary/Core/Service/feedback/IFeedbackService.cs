using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Service.feedback
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll();
        List<FeedbackDTO> GetApprovedFeedbacks();
        Feedback GetById(int id);
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        List<FeedbackDTO> GetAllFeedbackDTOs();
        void ChangeStatus(int id);
    }
}
