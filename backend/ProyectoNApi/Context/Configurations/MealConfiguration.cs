using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            // Validations
            builder.Property(m => m.Name).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Recipe).HasMaxLength(10000);
            builder.Property(m => m.TimeInMinutes).IsRequired();
            builder.Property(m => m.Difficulty).IsRequired().HasMaxLength(6).HasConversion<string>();

           
        }
    }
}