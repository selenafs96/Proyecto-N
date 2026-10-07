using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class NutritionalPlanMealConfiguration : IEntityTypeConfiguration<NutritionalPlanMeal>
    {
        public void Configure(EntityTypeBuilder<NutritionalPlanMeal> builder)
        {
            // Primary key configuration
            builder.HasKey(nm => new { nm.MealId, nm.PlanId });
            
            // Many to many relationship configuration
            builder.HasOne(nm => nm.NutritionalPlan).WithMany(m => m.NutritionalPlanMeal).HasForeignKey(nm => nm.PlanId);
            builder.HasOne(nm => nm.Meal).WithMany(m => m.NutritionalPlanMeal).HasForeignKey(nm => nm.MealId);

            //Validations
            builder.Property(nm => nm.MealSlot).IsRequired().HasConversion<string>().HasMaxLength(14);
            builder.Property(nm => nm.DayOfWeek).IsRequired().HasConversion<string>().HasMaxLength(9);

            
        }
    }
}