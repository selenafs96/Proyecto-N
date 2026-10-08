using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Context.Configurations
{
    public class NutritionalPlanConfiguration : IEntityTypeConfiguration<NutritionalPlan>
    {
        public void Configure(EntityTypeBuilder<NutritionalPlan> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);

            builder.Property(p => p.StartDate).IsRequired();

            builder.Property(p => p.Observations).HasMaxLength(5000);
        }
    }
}