using healthcare_and_patient_management_api.Enums;

namespace healthcare_and_patient_management_api.Models
{
    public class Doctor : User
    {
        public Guid DoctorId { get; set; } = Guid.newGuid();
        public Speciality Speciality { get; set; }

    }
}
