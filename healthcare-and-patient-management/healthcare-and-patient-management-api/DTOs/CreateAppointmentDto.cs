using healthcare_and_patient_management_api.Models;

namespace healthcare_and_patient_management_api.DTOs
{
    public class CreateAppointmentDto
    {
        public DateTime DateAdded { get; set; }
        public Patient? PatientId { get; set; }
        public Doctor? DoctorId { get; set; }
        public ClinicBranch? BranchId { get; set; }
    }
}
