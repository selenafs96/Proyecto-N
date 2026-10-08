using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;
namespace ProyectoNApi.Context.Configurations
{
        public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
        {
            public void Configure(EntityTypeBuilder<Nutrient> builder)
            {

                builder.Property(n => n.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(n => n.MeasurementUnit)
                    .IsRequired()
                    .HasMaxLength(20);

                builder.Property(n => n.ReferenceIntake)
                    .HasPrecision(10, 2)
                    .IsRequired(false);
            }
        }   
}