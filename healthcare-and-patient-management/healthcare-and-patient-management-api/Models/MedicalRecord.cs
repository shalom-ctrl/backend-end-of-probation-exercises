namespace healthcare_and_patient_management_api.Models
{
    public class MedicalRecord
    {
        public List<string> Diagnosis { get; set; }
        public Prescription prescription { get; set; }
    }
}
