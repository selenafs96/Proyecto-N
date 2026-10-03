using System.Diagnostics.CodeAnalysis;

namespace ProyectoNApi.Entities
{
    public class NutritionalPlanMeal
    {
        public required int MealId { get; set; }
        public Meal? Meal { get; set; }
        public required int PlanId { get; set; }
        public NutritionalPlan? NutritionalPlan { get; set; }
        public required string MealSlot { get; set; }
        public required string DayOfWeek { get; set; }
    }
}