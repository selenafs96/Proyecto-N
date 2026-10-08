using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{

    // Food + Patient relationship intermediate table
    public class RestrictionConfiguration : IEntityTypeConfiguration<Restriction>
    {
        public void Configure(EntityTypeBuilder<Restriction> builder)
        {
            // Primary key configuration
            builder.HasKey(r => new { r.FoodId, r.PatientId });

            // Many to many relationship configuration
            builder.HasOne(r => r.Food).WithMany(f => f.Restrictions).HasForeignKey(r => r.FoodId);
            builder.HasOne(r => r.Patient).WithMany(p => p.Restrictions).HasForeignKey(r => r.PatientId);

            // Validations
            builder.Property(r => r.Type).IsRequired().HasConversion<string>().HasMaxLength(20);
            builder.Property(p => p.Observations).HasMaxLength(5000);
        }
    }
}