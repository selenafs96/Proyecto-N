namespace ProyectoNApi.Entities
{
    public enum MealSlot
    {
        Breakfast,
        MorningSnack,
        Lunch,
        AfternoonSnack,
        Dinner,
        Preworkout,
        Postworkout
    }

    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public class NutritionalPlanMeal
    {
        public required int MealId { get; set; }
        public Meal? Meal { get; set; }
        public required int PlanId { get; set; }
        public NutritionalPlan? NutritionalPlan { get; set; }
        public required MealSlot MealSlot { get; set; }
        public required DayOfWeek DayOfWeek { get; set; }
    }
}