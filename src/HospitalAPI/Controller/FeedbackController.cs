using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.feedback;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAllFeedbackDTOs());
        }

        [HttpGet("/get-approved")]
        public ActionResult GetApprovedFeedbacks()
        {
            return Ok(_feedbackService.GetApprovedFeedbacks());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.Id)
            {
                return BadRequest();
            }

            try
            {
                _feedbackService.Update(feedback);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }
        [HttpPut("status/{id}")]
        public ActionResult ChangeStatus(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.Id)
            {
                return BadRequest();
            }
            try
            {
                _feedbackService.ChangeStatus(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(feedback);
            return NoContent();
        }
    }
}
