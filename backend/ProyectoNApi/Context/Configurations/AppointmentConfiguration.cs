using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // Validations
            builder.Property(a => a.AppointmentDateTime).IsRequired().HasColumnType("timestamp with time zone");

            builder.Property(a => a.Duration).IsRequired();

            builder.Property(a => a.State).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(a => a.Format).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(a => a.Type).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(a => a.Notes).HasMaxLength(5000);

            builder.Property(a => a.Reminder).HasColumnType("timestamp with time zone");

        }
    }
}