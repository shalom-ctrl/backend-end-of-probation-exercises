using healthcare_and_patient_management_api.Enums;

namespace healthcare_and_patient_management_api.Models
{
    public class Patient : User
    {
        public Guid PatientId { get; set; } = Guid.newGuid();
        public InsuranceProvider insuranceProvider { get; set; }
        const decimal BaseConsultationFee = 50.00;
        const int MaxDailyAppointments = 2;

        public static void Main()
        {
            var patient = new Dictionary<Id, MedicalRecord>()
            {

            };
        }
    }
}
