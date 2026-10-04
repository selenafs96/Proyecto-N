using Microsoft.EntityFrameworkCore;
using FluentValidation;

using ProyectoNApi.Context;
using ProyectoNApi.Entities;
using static ProyectoNApi.Validators.Utils.ValidatorsUtils;

namespace ProyectoNApi.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        private readonly ProyectoNContext _context;

        public PatientValidator(ProyectoNContext context)
        {
            _context = context;

            RuleFor(p => p.Dni).NotEmpty().WithMessage("El DNI es obligatorio.")
            .Length(9).WithMessage("El DNI debe tener 9 caracteres.")
            .Must(BeAValidDni).WithMessage("El DNI introducido no es válido.")
            .MustAsync(async (dni, cancellation) =>
                        {
                            bool alreadyExists = await _context.User.AnyAsync(u => u.Dni == dni, cancellation);
                            return !alreadyExists;
                        }).WithMessage("El DNI introducido ya existe.");

            RuleFor(p => p.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
            .MaximumLength(50).WithMessage("El nombre no puede contener más de 50 caracteres.");

            RuleFor(p => p.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.")
            .MaximumLength(100).WithMessage("El apellido no puede contener más de 100 caracteres.");

            RuleFor(p => p.Birthdate).NotEmpty().WithMessage("La fecha de nacimiento no puede estar vacía.")
            .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha de nacimiento no puede ser futura.")
            .GreaterThan(DateOnly.FromDateTime(DateTime.Today.AddYears(-120))).WithMessage("La fecha de nacimiento  introducida no es válida.");

            RuleFor(p => p.Gender).NotEmpty().WithMessage("El género no puede estar vacío.").IsInEnum().WithMessage("El género debe ser Masculino o Femenino.");

            RuleFor(p => p.Occupation).NotEmpty().WithMessage("La ocupación no puede estar vacía.").MaximumLength(100).WithMessage("La ocupación es demasiado larga.");

            RuleFor(p => p.Email).NotEmpty().WithMessage("El email no puede estar vacío.")
            .MaximumLength(150).WithMessage("El email es demasiado largo.")
            .EmailAddress().WithMessage("El formato del correo electrónico no es válido")
            .MustAsync(async (email, cancellation) =>
                        {
                            bool alreadyExists = await _context.User.AnyAsync(u => u.Email == email, cancellation);
                            return !alreadyExists;
                        }).WithMessage("El email introducido ya existe.");
            
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("El teléfono no puede estar vacío.")
            // Validates international phone numbers (E.164 standard: 2-15 digits, optional '+' prefix, no spaces/hyphens)
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("El formato del teléfono no es válido.");

            RuleFor(p => p.Street).MaximumLength(500).WithMessage("El campo Calle es demasiado largo.");

            RuleFor(p => p.StreetNumber).MaximumLength(20).WithMessage("El campo Calle es demasiado largo.");

            RuleFor(p => p.FloorOrDoor).MaximumLength(20).WithMessage("El campo Planta o Puerta es demasiado largo.");

            RuleFor(p => p.City).MaximumLength(100).WithMessage("El campo Ciudad es demasiado largo.");

            RuleFor(p => p.PostalCode).MaximumLength(20).WithMessage("El campo Código Postal es demasiado largo.");

            RuleFor(p => p.Province).MaximumLength(100).WithMessage("El campo Provincia es demasiado largo.");

            RuleFor(p => p.Country).MaximumLength(100).WithMessage("El campo País es demasiado largo.");

            RuleFor(p => p.PhysicalActivity).NotEmpty().WithMessage("El campo de actividad física no puede estar vacío.").IsInEnum().WithMessage("La actividad física solo puede ser: Sedentario, Ligero, Moderado, Intenso o Muy Intenso");

            RuleFor(p => p.AlcoholConsumption).NotNull().WithMessage("Debe indicarse el consumo de alcohol.");

            RuleFor(p => p.TobaccoConsumption).NotNull().WithMessage("Debe indicarse el consumo de tabaco.");

            RuleFor(p => p.Approach).NotEmpty().WithMessage("El enfoque no puede estar vacío.").IsInEnum().WithMessage("El enfoque solo puede ser: Pérdida de grasa, Ganancia de músculo, Recomposición, Mantenimiento o Clínico.");
            
            RuleFor(p => p.SpecialDiet).IsInEnum().WithMessage("Opción de dieta específica no válida.");

            RuleFor(p => p.Observations).MaximumLength(1000).WithMessage("El campo de observaciones es demasiado largo.");

            RuleFor(p => p.RegisterDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("La fecha de registro no puede ser futura.");

            RuleFor(p => p.IsActive).NotNull().WithMessage("Debe indicarse el estado activo o no activo del paciente.");
        }
    }
}