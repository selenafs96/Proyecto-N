using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class MealFoodConfiguration : IEntityTypeConfiguration<MealFood>
    {
        public void Configure(EntityTypeBuilder<MealFood> builder)
        {
            // Primary key configuration
            builder.HasKey(mf => new { mf.MealId, mf.FoodId });
            // Many to many relationship configuration
            builder.HasOne(mf => mf.Meal).WithMany(m => m.MealFood).HasForeignKey(mf => mf.MealId);
            builder.HasOne(mf => mf.Food).WithMany(f => f.MealFood).HasForeignKey(mf => mf.FoodId);

            // Validations
            builder.Property(mf => mf.QuantityInGrams).IsRequired().HasPrecision(10,2);
            
           
        }
    }
}