using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using HospitalLibrary.Settings;
using HospitalLibrary.Core.Dto;

namespace HospitalLibrary.Core.Repository.feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HospitalDbContext _context;

        public FeedbackRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }
        public List<FeedbackDTO> GetAllFeedbackDTOs()
        {
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            foreach (Feedback feedback in GetAll())
            {
                    FeedbackDTO feedbackDTO = new FeedbackDTO(feedback);
                    if (!feedback.IsAnonymous)
                    {
                        Patient patient = _context.Patients.Find(feedback.patientId);
                        feedbackDTO.PatientName = patient.FirstName + " " + patient.LastName;
                    }
                    else
                    {
                        feedbackDTO.PatientName = "Anonymous";
                    }
                    feedbacks.Add(feedbackDTO);
            }
            return feedbacks.OrderBy(x => x.Id).ToList();
        }
        public List<FeedbackDTO> GetApprovedFeedbackDTOs()
        {
            List<FeedbackDTO> approvedFeedbacks = new List<FeedbackDTO>();
            
            foreach(Feedback feedback in GetAll())
            {
                if (feedback.IsApproved)
                {
                    FeedbackDTO feedbackDTO = new FeedbackDTO(feedback);
                    if (!feedback.IsAnonymous)
                    {
                        Patient patient = _context.Patients.Find(feedback.patientId);
                        feedbackDTO.PatientName = patient.FirstName + " " + patient.LastName;
                    }
                    else
                    {
                        feedbackDTO.PatientName = "Anonymous";
                    }
                    approvedFeedbacks.Add(feedbackDTO);
                }
            }
            return approvedFeedbacks;
        }

        public Feedback GetById(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public void Create(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void Update(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }
    }
}
