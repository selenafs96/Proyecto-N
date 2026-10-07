using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class PatientPathologyConfiguration : IEntityTypeConfiguration<PatientPathology>
    {
        public void Configure(EntityTypeBuilder<PatientPathology> builder)
        {
            // Primary key configuration
            builder.HasKey(pp => new { pp.PatientId, pp.PathologyId });

            // Many to many relationship configuration
            builder.HasOne(pp => pp.Patient).WithMany(p => p.PatientPathology).HasForeignKey(pp => pp.PatientId);
            builder.HasOne(pp => pp.Pathology).WithMany(pt => pt.PatientPathology).HasForeignKey(pp => pp.PathologyId);

            // Validations
            builder.Property(pp => pp.Notes).HasMaxLength(1000);
        }
    }
}