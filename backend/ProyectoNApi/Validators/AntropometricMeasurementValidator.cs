using FluentValidation;
using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class AnthropometricMeasurementValidator : AbstractValidator<AnthropometricMeasurement>
    {
        public AnthropometricMeasurementValidator() {
            RuleFor(a => a.Date).NotEmpty().WithMessage("La fecha no puede estar vacía.")
            .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha no puede ser futura.");
        }
    }
}