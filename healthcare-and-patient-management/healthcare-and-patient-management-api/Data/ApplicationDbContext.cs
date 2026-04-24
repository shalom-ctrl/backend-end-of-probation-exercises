using healthcare_and_patient_management_api.Models;

namespace healthcare_and_patient_management_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public DbSet<ClinicBranch> Clinicbranch { get; set; } = null!;
        public DbSet<Prescription> Prescriptions { get; set; } = null!;
    }
}
