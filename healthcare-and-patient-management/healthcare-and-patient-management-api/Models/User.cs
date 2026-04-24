namespace healthcare_and_patient_management_api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.newGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
