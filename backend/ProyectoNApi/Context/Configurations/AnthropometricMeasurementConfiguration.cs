using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class AnthropometricMeasurementConfiguration : IEntityTypeConfiguration<AnthropometricMeasurement>
    {
        public void Configure(EntityTypeBuilder<AnthropometricMeasurement> builder)
        {
            // Validations
            builder.Property(a => a.Date).IsRequired().HasColumnType("date");

            builder.Property(a => a.Weight).HasPrecision(5, 2);

            builder.Property(a => a.Height).HasPrecision(5, 2);

            builder.Property(a => a.FatPercentage).HasPrecision(5, 2);

            builder.Property(a => a.MusclePercentage).HasPrecision(5, 2);

            builder.Property(a => a.Waist).HasPrecision(5, 2);

            builder.Property(a => a.Hip).HasPrecision(5, 2);

            builder.Property(a => a.Wrist).HasPrecision(5, 2);

            builder.Property(a => a.Thigh).HasPrecision(5, 2);

            builder.Property(a => a.Calf).HasPrecision(5, 2);

            builder.Property(a => a.RelaxedArm).HasPrecision(5, 2);

            builder.Property(a => a.ContractedArm).HasPrecision(5, 2);

            builder.Property(a => a.BicipitalSkinfold).HasPrecision(5, 2);
                
            builder.Property(a => a.TricipitalSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.SubscapularSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.SuprailiacSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.AbdominalSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.SupraspinalSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.FrontThighSkinfold).HasPrecision(5, 2);

            builder.Property(a => a.MedialCalfSkinfold).HasPrecision(5, 2);

            builder.Property(p => p.Observations).HasMaxLength(5000).HasColumnType("text");

        }
    }
}