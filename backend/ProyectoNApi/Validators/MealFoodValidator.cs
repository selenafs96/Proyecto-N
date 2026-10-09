using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class MealFoodValidator : AbstractValidator<MealFood>
    {
        public MealFoodValidator()
        {
            RuleFor(x => x.FoodId).GreaterThan(0).WithMessage("El identificador del alimento no es válido.");

            RuleFor(x => x.QuantityInGrams).GreaterThan(0).WithMessage("La cantidad en gramos debe ser mayor a cero.")
                .LessThanOrEqualTo(10000).WithMessage("La cantidad no puede superar los 10,000 gramos.");
        }
    }
}