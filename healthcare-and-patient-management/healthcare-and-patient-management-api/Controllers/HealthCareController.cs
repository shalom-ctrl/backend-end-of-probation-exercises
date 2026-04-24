using healthcare_and_patient_management_api.DTOs;
using healthcare_and_patient_management_api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web.Mvc;

namespace healthcare_and_patient_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCareController : ControllerBase
    {
        private readonly IHealthcareService _healthcareService = new();
        public HealthCareController(IHealthcareService healthcareService)
        {
            _healthcareService = healthcareService;
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            return _healthcareService.GetAllPatients();
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(Guid id)
        {
            var appointment = _healthcareService.GetPatientById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentDto dto)
        {
            var appointment = _healthcareService.CreateAppointment(dto);
            if(appointment == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(UpdateAppointmentDto dto, Guid id)
        {
            var appointment = _healthcareService.UpdateAppointment(dto, id);
            if(appointment == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(Guid id)
        {
            var appointment = _healthcareService.DeleteById(id);
            if(appointment == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
