using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // Validations
            builder.Property(p => p.Dni).IsRequired().HasColumnType("CHAR(9)");
            builder.HasIndex(p => p.Dni).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Birthdate).IsRequired().HasColumnType("date");

            builder.Property(p => p.Gender).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(p => p.Occupation).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(16);

            builder.Property(p => p.Street).HasMaxLength(500);

            builder.Property(p => p.StreetNumber).HasMaxLength(20);

            builder.Property(p => p.FloorOrDoor).HasMaxLength(20);

            builder.Property(p => p.City).HasMaxLength(100);

            builder.Property(p => p.PostalCode).HasMaxLength(20);

            builder.Property(p => p.Province).HasMaxLength(100);

            builder.Property(p => p.Country).HasMaxLength(100);

            builder.Property(p => p.PhysicalActivity).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(p => p.AlcoholConsumption).IsRequired();

            builder.Property(p => p.TobaccoConsumption).IsRequired();

            builder.Property(p => p.Approach).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(p => p.SpecialDiet).IsRequired().HasConversion<string>().HasMaxLength(20);

            builder.Property(p => p.Observations).HasMaxLength(5000);

            builder.Property(p => p.RegisterDate).IsRequired().HasColumnType("date");

            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}