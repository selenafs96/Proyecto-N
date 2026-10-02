using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class Food
    {
        [Key]
        public required int FoodId { get; set; }
        public required string Name { get; set; }
        public required string Source { get; set; }
        // Relationship table between Nutrient and Food
        public ICollection<NutrientFood> NutrientFood { get; set; } = new List<NutrientFood>();
        // Relationship table between Meal and Food
        public ICollection<MealFood> MealFood { get; set; } = new List<MealFood>();
        // Relationship table between Food and Patient
        public ICollection<Restriction> Restrictions { get; set; } = new List<Restriction>();

    }
}