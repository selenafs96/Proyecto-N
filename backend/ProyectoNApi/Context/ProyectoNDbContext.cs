using Microsoft.EntityFrameworkCore;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context
{
    public class ProyectoNDbContext : DbContext
    {
        public ProyectoNDbContext(DbContextOptions<ProyectoNDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<AnthropometricMeasurement> AnthropometricMeasurement { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Treatment> PatientTreatment { get; set; }
        public DbSet<PatientUser> PatientUser { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<MealFood> MealFood { get; set; }
        public DbSet<Nutrient> Nutrient { get; set; }
        public DbSet<NutrientFood> NutrientFood { get; set; }
        public DbSet<NutritionalPlan> NutritionalPlan { get; set; }
        public DbSet<NutritionalPlanMeal> NutritionalPlanMeal { get; set; }
        public DbSet<Pathology> Pathology { get; set; }
        public DbSet<PatientPathology> PatientPathology { get; set; }
        public DbSet<Restriction> Restriction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Authomatically applies classes implementing IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProyectoNDbContext).Assembly);
        }
    }
} 