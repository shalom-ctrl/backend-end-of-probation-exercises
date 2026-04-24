using healthcare_and_patient_management_api.DTOs;
using healthcare_and_patient_management_api.Models;

namespace healthcare_and_patient_management_api.Interface
{
    public interface IHealthcareService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(Guid id);
        void CreateAppointment(CreateAppointmentDto dto);
        Prescription GetPatientByPrescription(string code);
        void UpdateAppointment(UpdateAppointmentDto dto, Guid id);
        bool DeleteById(Guid id);
    }
}
