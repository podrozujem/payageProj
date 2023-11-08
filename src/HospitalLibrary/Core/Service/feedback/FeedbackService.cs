using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.feedback;

namespace HospitalLibrary.Core.Service.feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }
        public List<FeedbackDTO> GetAllFeedbackDTOs()
        {
            return _feedbackRepository.GetAllFeedbackDTOs();
        }
        public List<FeedbackDTO> GetApprovedFeedbacks()
        {
            return _feedbackRepository.GetApprovedFeedbackDTOs();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public void Create(Feedback feedback)
        {
            _feedbackRepository.Create(feedback);
        }

        public void Update(Feedback feedback)
        {
            _feedbackRepository.Update(feedback);
        }

        public void Delete(Feedback feedback)
        {
            _feedbackRepository.Delete(feedback);
        }
        public void ChangeStatus(int id)
        {
            Feedback feedback = _feedbackRepository.GetById(id);
            if(feedback.IsApproved)
                feedback.IsApproved = false;
            else
                feedback.IsApproved = true;
            _feedbackRepository.Update(feedback);
        }
    }
}
