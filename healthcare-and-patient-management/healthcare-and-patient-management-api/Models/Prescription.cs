namespace healthcare_and_patient_management_api.Models
{
    public class Prescription
    {
        public string MedicationName { get; set; }
        public int Dosage { get; set; }
        public int DurationDays { get; set; }
    }
}
