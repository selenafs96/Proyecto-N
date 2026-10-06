using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.AppointmentDateTime).NotEmpty().WithMessage("La fecha y la hora de la cita son obligatorias.").GreaterThan(DateTimeOffset.Now).WithMessage("La fecha y hora tienen que ser futuras.").LessThan(DateTimeOffset.Now.AddYears(1)).WithMessage("No se pueden programar citas con más de un año de antelación.");
            
            RuleFor(a => a.Duration).NotEmpty().WithMessage("La duración de la cita es obligatoria.").InclusiveBetween(20, 120).WithMessage("La duración de la cita debe estar entre 20 y 120 minutos");
            
            RuleFor(a => a.State).NotEmpty().WithMessage("El estado de la cita es obligatorio.").IsInEnum().WithMessage("El estado de la cita solo puede ser Programada, Confirmada, Completada, Cancelada o No Presentado.");
            
            RuleFor(a => a.Format).NotEmpty().WithMessage("El formato de la cita es obligatorio.").IsInEnum().WithMessage("El formato de la cita solo puede ser Presencial o Telemática.");
            
            RuleFor(a => a.Type).NotEmpty().WithMessage("El tipo de cita es obligatorio.").IsInEnum().WithMessage("El tipo de cita solo puede ser Consulta Inicial, Seguimiento o Consulta Específica.");
            
            RuleFor(a => a.Notes).MaximumLength(5000).WithMessage("El campo de notas es demasiado largo.");

            RuleFor(a => a.Reminder).LessThanOrEqualTo(DateTimeOffset.Now).WithMessage("La fecha del recordatorio no puede ser en el futuro.")
                .LessThan(a => a.AppointmentDateTime)
                .WithMessage("El recordatorio debe enviarse antes de que ocurra la cita.")
                .When(a => a.Reminder.HasValue);
        }
    }
}