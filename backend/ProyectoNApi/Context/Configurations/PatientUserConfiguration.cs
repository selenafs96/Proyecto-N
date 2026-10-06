using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class PatientUserConfiguration : IEntityTypeConfiguration<PatientUser>
    {
        public void Configure(EntityTypeBuilder<PatientUser> builder)
        {

            // Primary key configuration
            builder.HasKey(pu => new { pu.PatientId, pu.UserId });

            // Many to many relationship configuration
            builder.HasOne(pu => pu.Patient).WithMany(p => p.PatientUsers).HasForeignKey(pu => pu.PatientId);
            builder.HasOne(pu => pu.User).WithMany(u => u.PatientUsers).HasForeignKey(pu => pu.UserId);
        }
    }
}