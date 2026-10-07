using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class NutrientFoodConfiguration : IEntityTypeConfiguration<NutrientFood>
    {
        public void Configure(EntityTypeBuilder<NutrientFood> builder)
        {
            // Primary key configuration
            builder.HasKey(nf => new { nf.NutrientId, nf.FoodId });
            
            // Many to many relationship configuration
            builder.HasOne(nf => nf.Nutrient).WithMany(n => n.NutrientFood).HasForeignKey(nf => nf.NutrientId);
            builder.HasOne(nf => nf.Food).WithMany(f => f.NutrientFood).HasForeignKey(nf => nf.FoodId);

            //Validations
            builder.Property(mf => mf.QuantityPer100g).IsRequired().HasPrecision(10,2);

        }
    }
}