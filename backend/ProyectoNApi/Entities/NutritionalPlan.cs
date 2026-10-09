using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class NutritionalPlan
    {
        [Key]
        public required int PlanId { get; set; }
        public required string Name { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Observations { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int UserId { get; set; }
        public User? User { get; set; }

        //Relationship table between NutritionalPlan and Meal
        public ICollection<NutritionalPlanMeal> NutritionalPlanMeal { get; set; } = new List<NutritionalPlanMeal>(); 
    }
}