using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class MealValidator : AbstractValidator<Meal>
    {
        public MealValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("El nombre de la comida es obligatorio.")
                .MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres.")
                .MaximumLength(200).WithMessage("El nombre no puede superar los 200 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s,\-\(\)]+$").WithMessage("El nombre contiene caracteres no válidos.")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El nombre no puede estar compuesto solo por espacios.");
            RuleFor(m => m.Recipe).MaximumLength(10000).WithMessage("La receta es demasiado larga.");
            RuleFor(m => m.TimeInMinutes).NotEmpty().WithMessage("La duración es obligatoria.").InclusiveBetween(0, 1440).WithMessage("El tiempo de preparación debe estar entre 0 y 1440 minutos.");
            RuleFor(m => m.Difficulty).NotEmpty().WithMessage("Es obligatorio indicar la dificultad.").IsInEnum().WithMessage("La dificultad solo puede ser Fácil, Media, Difícil o Experto.");
        }
    }
}