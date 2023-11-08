using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.payment;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService; 

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService; 
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_paymentService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpGet("/getAllCapturedList")]
        public ActionResult GetCaptured()
        {
            return Ok(_paymentService.GetCaptured());
        }

        [HttpGet("/getAllCapturedListPaginated/{page}/{pageSize}")]
        public ActionResult GetCapturedPaginated(int page, int pageSize)
        {
            return Ok(_paymentService.GetAllCaptured(page, pageSize));
        }
        [HttpPost]
        public ActionResult Create(CreatePaymentDTO paymentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payment payment = new Payment();
            payment.Id = Guid.NewGuid().ToString("N");
            payment.CVV = paymentDTO.CVV;
            payment.PaymentStatus = PaymentStatus.AUTHORIZED; 
            payment.Currency = paymentDTO.Currency;
            payment.CardHolderNumber = paymentDTO.CardHolderNumber;
            payment.ExpirationMonth = paymentDTO.ExpirationMonth;
            payment.ExpirationYear = paymentDTO.ExpirationYear; 
            payment.Amount = paymentDTO.Amount;
            payment.OrderReference = paymentDTO.OrderReference;
            payment.HolderName = paymentDTO.HolderName;

            _paymentService.Create(payment);
            return CreatedAtAction("GetById", new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.Id)
            {
                return BadRequest();
            }

            try
            {
                _paymentService.Update(payment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(payment);
        }

        [HttpPut("changeStatusToVoid/{id}")]
        public ActionResult ChangePaymentToVoided(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _paymentService.UpdateStatusVoid(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("changeStatusToCaptured/{id}")]
        public ActionResult ChangePaymentToCaptured(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _paymentService.UpdateStatusCaptured(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
