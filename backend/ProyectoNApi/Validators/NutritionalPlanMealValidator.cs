using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class NutritionalPlanMealValidator : AbstractValidator<NutritionalPlanMeal>
    {
        public NutritionalPlanMealValidator()
        {
           RuleFor(n => n.MealId)
                .GreaterThan(0).WithMessage("El identificador de la comida no es válido.");

            RuleFor(n => n.PlanId)
                .GreaterThan(0).WithMessage("El identificador del plan nutricional no es válido.");

           RuleFor(n => n.MealSlot).IsInEnum().WithMessage("El horario de comida solo puede ser Desayuno, MediaMañana, Comida, Merienda, Cena, Pre-entreno o Post-entreno.");
           
           RuleFor(n => n.DayOfWeek).IsInEnum().WithMessage("Día de la semana no válido.");
        }
    }
}