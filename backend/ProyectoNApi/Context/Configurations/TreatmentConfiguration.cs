using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{

    // Food + Patient relationship intermediate table
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            // Unique index to ensure that a patient can't have duplicate treatments with the same name.
            builder.HasIndex(t => new { t.PatientId, t.Name }).IsUnique();

            // Validations
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

            builder.Property(t => t.Type).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(t => t.Dose).IsRequired().HasMaxLength(100);

            builder.Property(t => t.Frequency).IsRequired().HasMaxLength(100);
        }
    }
}