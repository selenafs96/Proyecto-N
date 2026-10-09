using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class PatientPathologyValidator : AbstractValidator<PatientPathology>
    {
        public PatientPathologyValidator()
        {
            RuleFor(pp => pp.DiagnosedDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow.ToLocalTime())).WithMessage("La fecha de diagnóstico no puede ser posterior al día de hoy.")
                .When(x => x.DiagnosedDate.HasValue); 

            RuleFor(pp => pp.Notes).MaximumLength(5000).WithMessage("El campo de notas es demasiado largo.");
        }
    }
}