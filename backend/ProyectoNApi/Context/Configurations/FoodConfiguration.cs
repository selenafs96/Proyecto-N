using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            // Validations
            builder.Property(f => f.Name).IsRequired().HasMaxLength(200);
            builder.Property(f => f.Source).IsRequired().HasMaxLength(100);

           
        }
    }
}