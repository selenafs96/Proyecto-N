using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class NutritionalPlanValidator : AbstractValidator<NutritionalPlan>
    {
        public NutritionalPlanValidator()
        {
            RuleFor(n => n.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
                .MaximumLength(150).WithMessage("El nombre no puede contener más de 150 caracteres.").MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s,\-\(\)]+$").WithMessage("El nombre contiene caracteres no válidos.")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El nombre no puede estar compuesto solo por espacios.");

            RuleFor(n => n.StartDate)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria.");

            RuleFor(n => n.EndDate).GreaterThan(x => x.StartDate).WithMessage("La fecha de finalización debe ser posterior a la fecha de inicio.").When(x => x.EndDate.HasValue);
        
            RuleFor(n => n.Observations).MaximumLength(5000).WithMessage("El campo observaciones es demasiado largo.");
        }
    }
}