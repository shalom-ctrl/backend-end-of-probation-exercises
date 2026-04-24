using healthcare_and_patient_management_api.Data;
using healthcare_and_patient_management_api.DTOs;
using healthcare_and_patient_management_api.Interface;
using healthcare_and_patient_management_api.Models;

namespace healthcare_and_patient_management_api.Service
{
    public class HealthCareService : IHealthcareService
    {
        private readonly ApplicationDbContext _context = new();
        public HealthCareService(ApplicationDbContext context)
        {
            _context = ApplicationDbContext;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(Guid id)
        {
            return _context.FirstorDefault(x => x.Id == id);
        }

        public void CreateAppointment(CreateAppointmentDto dto)
        {
            var appointment = new Patient
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                BranchId = dto.BranchId,
                DateAdded = DateTime.UtcNow(),

            };

            _context.Patients.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(UpdateAppointmentDto dto, Guid id)
        {
            var appointment = _context.Patients.Find(id);
            if (appointment == null)
            {
                return;
            }
            appointment.DoctorId = dto.DoctorId;
            appointment.BranchId = dto.BranchId;
            appointment.PatientId = dto.PatientId;
            appointment.DateAdded = dto.DateAdded;

            _context.SaveChanges();
        }

        public bool DeleteById(Guid id)
        {
            var Patient = _context.Patients.Find(id);
            if(Patient == null)
            {
                return false;
            }

            _context.Patients.Remove(Patient);
            _context.Patients.SaveChanges();
            return true;
        }
    }
}
