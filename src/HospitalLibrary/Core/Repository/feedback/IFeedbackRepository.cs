using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;


namespace HospitalLibrary.Core.Repository.feedback
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        List<FeedbackDTO> GetApprovedFeedbackDTOs();
        Feedback GetById(int id);
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        List<FeedbackDTO> GetAllFeedbackDTOs();
    }
}
