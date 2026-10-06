using Microsoft.EntityFrameworkCore;
using FluentValidation;

using ProyectoNApi.Context;
using ProyectoNApi.Entities;
using static ProyectoNApi.Validators.Utils.ValidatorsUtils;

namespace ProyectoNApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {

        private readonly ProyectoNDbContext _context;
        public UserValidator(ProyectoNDbContext context) {
            _context = context;

            RuleFor(u => u.Dni).NotEmpty().WithMessage("El DNI es obligatorio.")
            .Length(9).WithMessage("El DNI debe tener 9 caracteres.")
            .Must(BeAValidDni).WithMessage("El DNI introducido no es válido.")
            .MustAsync(async (dni, cancellation) =>
                        {
                            bool alreadyExists = await _context.User.AnyAsync(u => u.Dni == dni, cancellation);
                            return !alreadyExists;
                        }).WithMessage("El DNI introducido ya existe.");

            RuleFor(u => u.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
            .MaximumLength(50).WithMessage("El nombre no puede contener más de 50 caracteres.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s,\-\(\)]+$").WithMessage("El nombre contiene caracteres no válidos.")
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El nombre no puede estar compuesto solo por espacios.");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.")
            .MaximumLength(100).WithMessage("El apellido no puede contener más de 100 caracteres.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s,\-\(\)]+$").WithMessage("El apellido contiene caracteres no válidos.")
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El apellido no puede estar compuesto solo por espacios.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("El email no puede estar vacío.")
            .MaximumLength(150).WithMessage("El email es demasiado largo.")
            .EmailAddress().WithMessage("El formato del correo electrónico no es válido")
            .MustAsync(async (email, cancellation) =>
                        {
                            bool alreadyExists = await _context.User.AnyAsync(u => u.Email == email, cancellation);
                            return !alreadyExists;
                        }).WithMessage("El DNI introducido ya existe.");

            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("El teléfono no puede estar vacío.")
            // Validates international phone numbers (E.164 standard: 2-15 digits, optional '+' prefix, no spaces/hyphens)
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("El formato del teléfono no es válido.");

            RuleFor(u => u.PhotoUrl).MaximumLength(2048).WithMessage("URL demasiado larga.");

        }
    }

}


