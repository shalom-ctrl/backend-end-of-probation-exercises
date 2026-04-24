namespace healthcare_and_patient_management_api.Models
{
    public struct ClinicBranch
    {
        public Guid BranchId { get; set; } = Guid.newGuid();
        public class GeoLocation
        {
            public float Latitude { get; set; }
            public float Longitude { get; set; }
        }
    }
}
