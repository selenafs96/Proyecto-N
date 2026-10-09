using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class NutrientFoodValidator : AbstractValidator<NutrientFood>
    {
        public NutrientFoodValidator()
        {
            RuleFor(x => x.FoodId).GreaterThan(0).WithMessage("El identificador del alimento no es válido.");

            RuleFor(x => x.QuantityPer100g).GreaterThan(0).WithMessage("La cantidad por 100g debe ser mayor a cero.")
                .LessThanOrEqualTo(100).WithMessage("La cantidad por 100g no puede superar los 100 gramos.");
        }
    }
}