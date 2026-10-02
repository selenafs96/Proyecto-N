using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class Nutrient
    {
        [Key]
        public required int NutrientId { get; set; }
        public required string Name { get; set; }
        public required string MeasurementUnit { get; set; }
        public decimal? ReferenceIntake { get; set; }

        // Relationship table between Nutrient and Food
        public ICollection<NutrientFood> NutrientFood { get; set; } = new List<NutrientFood>();
    }
}