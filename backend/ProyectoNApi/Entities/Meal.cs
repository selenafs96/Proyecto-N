using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class Meal
    {
        [Key]
        public required int MealId { get; set; }
        public required string Name { get; set; }
        public string? Recipe { get; set; }
        public TimeOnly? TimeInMinutes { get; set; }
        public string? Difficulty { get; set; }
        //Relationship table between NutritionalPlan and Meal
        public ICollection<NutritionalPlanMeal> NutritionalPlanMeal { get; set; } = new List<NutritionalPlanMeal>();
         // Relationship table between Meal and Food
        public ICollection<MealFood> MealFood { get; set; } = new List<MealFood>();
    }
}