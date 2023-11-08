using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.dailyMeasurements;
using HospitalLibrary.Core.Service.doctor;
using HospitalLibrary.Core.Service.patient;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyMeasurementsController : ControllerBase
    {
        private readonly IDailyMeasurementsService dailyMeasurementsService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public DailyMeasurementsController(IDailyMeasurementsService dailyMeasurementsService, IDoctorService doctorService, IPatientService patientService)
        {
            this.dailyMeasurementsService = dailyMeasurementsService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        //GET: api/dailyMeasurements
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(dailyMeasurementsService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var dailyMeasurements = dailyMeasurementsService.GetById(id);
            if (dailyMeasurements == null)
            {
                return NotFound();
            }
            return Ok(dailyMeasurements);
        }

        [HttpPost]
        public ActionResult Create(CreateDailyMeasurementsDTO createDailyMeasurementsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DailyMeasurements dailyMeasurements = new DailyMeasurements();

            dailyMeasurements.DailyMeasurementsId = Guid.NewGuid().ToString();
            dailyMeasurements.DateTimeOfMeasurements = DateTime.Now;
            dailyMeasurements.Doctor = _doctorService.GetById(createDailyMeasurementsDTO.DoctorId);
            dailyMeasurements.Patient = _patientService.GetById(createDailyMeasurementsDTO.PatientId);
            dailyMeasurements.BloodPreasure = createDailyMeasurementsDTO.BloodPreasure;
            dailyMeasurements.BloodSugar = createDailyMeasurementsDTO.BloodSugar;
            dailyMeasurements.FatPercentage = createDailyMeasurementsDTO.FatPercentage;
            dailyMeasurements.Weight = createDailyMeasurementsDTO.Weight;
            dailyMeasurements.MenstrualCycle = Convert.ToDateTime(createDailyMeasurementsDTO.MenstrualCycle);

            dailyMeasurementsService.Create(dailyMeasurements);
            return CreatedAtAction("GetById", new { id = dailyMeasurements.DailyMeasurementsId }, dailyMeasurements);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, DailyMeasurements dailyMeasurements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dailyMeasurements.DailyMeasurementsId)
            {
                return BadRequest();
            }

            try
            {
                dailyMeasurementsService.Update(dailyMeasurements);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(dailyMeasurements);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var dailyMeasurements = dailyMeasurementsService.GetById(id);
            if (dailyMeasurements == null)
            {
                return NotFound();
            }

            dailyMeasurementsService.Delete(dailyMeasurements);
            return NoContent();
        }
    }
}
