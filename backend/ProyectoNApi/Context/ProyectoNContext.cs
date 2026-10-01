using Microsoft.EntityFrameworkCore;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context
{
    public class ProyectoNContext : DbContext
    {
        public ProyectoNContext(DbContextOptions<ProyectoNContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<AnthropometricMeasurement> AnthropometricMeasurement { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<PatientTreatment> PatientTreatment { get; set; }
        public DbSet<PatientUser> PatientUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration of the composite primary key for the intermediate table PatientUser
            modelBuilder.Entity<PatientUser>().HasKey(pu => new { pu.PatientId, pu.UserId });

            // Configuration of the relationships of the intermediate table PatientUser
            modelBuilder.Entity<PatientUser>().HasOne(pu => pu.Patient).WithMany(p => p.PatientUsers).HasForeignKey(pu => pu.PatientId);
            modelBuilder.Entity<PatientUser>().HasOne(pu => pu.User).WithMany(u => u.PatientUsers).HasForeignKey(pu => pu.UserId);
        }
    }
} 