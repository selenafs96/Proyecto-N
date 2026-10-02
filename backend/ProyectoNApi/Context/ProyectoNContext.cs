using System.ComponentModel.DataAnnotations.Schema;
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

            // Configuration of the composite primary key for the intermediate tables
            modelBuilder.Entity<PatientUser>().HasKey(pu => new { pu.PatientId, pu.UserId });
            modelBuilder.Entity<NutritionalPlanMeal>().HasKey(nm => new { nm.MealId, nm.PlanId });
            modelBuilder.Entity<NutrientFood>().HasKey(nf => new { nf.NutrientId, nf.FoodId });
            modelBuilder.Entity<MealFood>().HasKey(mf => new { mf.MealId, mf.FoodId });
            modelBuilder.Entity<Restriction>().HasKey(r => new { r.FoodId, r.PatientId });

            // Configuration of the many to many relationships for the intermediate tables
            // PatientUser
            modelBuilder.Entity<PatientUser>().HasOne(pu => pu.Patient).WithMany(p => p.PatientUsers).HasForeignKey(pu => pu.PatientId);
            modelBuilder.Entity<PatientUser>().HasOne(pu => pu.User).WithMany(u => u.PatientUsers).HasForeignKey(pu => pu.UserId);

            // NutritionalPlanMeal
            modelBuilder.Entity<NutritionalPlanMeal>().HasOne(nm => nm.NutritionalPlan).WithMany(m => m.NutritionalPlanMeal).HasForeignKey(nm => nm.PlanId);
            modelBuilder.Entity<NutritionalPlanMeal>().HasOne(nm => nm.Meal).WithMany(m => m.NutritionalPlanMeal).HasForeignKey(nm => nm.MealId);

            // NutrientFood
            modelBuilder.Entity<NutrientFood>().HasOne(nf => nf.Nutrient).WithMany(n => n.NutrientFood).HasForeignKey(nf => nf.NutrientId);
            modelBuilder.Entity<NutrientFood>().HasOne(nf => nf.Food).WithMany(f => f.NutrientFood).HasForeignKey(nf => nf.FoodId);

            // MealFood
            modelBuilder.Entity<MealFood>().HasOne(mf => mf.Meal).WithMany(m => m.MealFood).HasForeignKey(mf => mf.MealId);
            modelBuilder.Entity<MealFood>().HasOne(mf => mf.Food).WithMany(f => f.MealFood).HasForeignKey(mf => mf.FoodId);

            //Restrictions (Food + Patient)
            modelBuilder.Entity<Restriction>().HasOne(r => r.Food).WithMany(f => f.Restrictions).HasForeignKey(r => r.FoodId);
            modelBuilder.Entity<Restriction>().HasOne(r => r.Patient).WithMany(p => p.Restrictions).HasForeignKey(r => r.PatientId);

        }
    }
} 