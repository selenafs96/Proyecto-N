using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Validations
            builder.Property(u => u.Dni).IsRequired().HasColumnType("CHAR(9)");
            builder.HasIndex(u => u.Dni).IsUnique();

            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);

            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(16);

            builder.Property(u => u.PhotoUrl).HasMaxLength(2048);

           
        }
    }
}