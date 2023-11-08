using HospitalLibrary.Core.Dto;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service.appointment;
using HospitalLibrary.Core.Service.building;
using HospitalLibrary.Core.Service.doctor;
using HospitalLibrary.Core.Service.patient;
using HospitalLibrary.Core.Service.room;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IRoomService _roomService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService, IRoomService roomService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
            _roomService = roomService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var building = _appointmentService.GetById(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        [HttpGet("getAllAppointmentsByDoctorId/{id}")]
        public ActionResult GetAllAppointmentsByDoctorId(string id)
        {
            return Ok(_appointmentService.GetAllAppointmentDTOsByDoctorId(id));
        }

        [HttpPost]
        public ActionResult Create(AppointmentCreationDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Appointment appointment = new Appointment();

            appointment.AppointmentId = Guid.NewGuid().ToString("N");
            appointment.AppointmentType = appointmentDTO.AppointmentType;
            appointment.Doctor = _doctorService.GetById(appointmentDTO.doctorId);
            appointment.Patient = _patientService.GetById(appointmentDTO.patientId);
            appointment.Room = _roomService.GetById(appointmentDTO.roomId);
            appointment.Date = appointmentDTO.Date;
            appointment.StartTime = DateTime.Parse("00:00");
            appointment.StartTime = appointment.StartTime.AddHours(appointmentDTO.hours);
            appointment.StartTime = appointment.StartTime.AddMinutes(appointmentDTO.minutes);
            if (appointmentDTO.AppointmentType == AppointmentType.EXAMINATION)
            {
                appointment.EndTime = appointment.StartTime;
                appointment.EndTime = appointment.EndTime.AddMinutes(10);
            }
            else
            {
                appointment.EndTime = appointment.StartTime;
                appointment.EndTime = appointment.EndTime.AddMinutes(30);
            }

            _appointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            try
            {
                _appointmentService.Update(appointment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(appointment);
            return NoContent();
        }

    }
}
