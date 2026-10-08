using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class TreatmentValidator : AbstractValidator<Treatment>
    {
        public TreatmentValidator() {
             RuleFor(t => t.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
                .MaximumLength(100).WithMessage("El nombre no puede contener más de 100 caracteres.").MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres.")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El nombre no puede estar compuesto solo por espacios.");

                RuleFor(p => p.Type).IsInEnum().WithMessage("El tipo solo puede ser Medicación o Suplemento.");

                RuleFor(t => t.Dose).NotEmpty().WithMessage("La dosis es obligatoria.").MaximumLength(100).WithMessage("La dosis no puede superar los 100 caracteres.");
                
                RuleFor(t => t.Frequency).NotEmpty().WithMessage("La frecuencia es obligatoria.").MaximumLength(100).WithMessage("La frecuencia no puede superar los 100 caracteres.");
        }
    }
}


