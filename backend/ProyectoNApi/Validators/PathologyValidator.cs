using Microsoft.EntityFrameworkCore;
using FluentValidation;

using ProyectoNApi.Context;
using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class PathologyValidator : AbstractValidator<Pathology>
    {

        private readonly ProyectoNDbContext _context;
        public PathologyValidator(ProyectoNDbContext context) {
            _context = context;

           RuleFor(p => p.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
            .MaximumLength(100).WithMessage("El nombre no puede contener más de 100 caracteres.")
            .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ0-9\s,\-\(\)]+$").WithMessage("El nombre contiene caracteres no válidos.")
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("El nombre no puede estar compuesto solo por espacios.")
            .MustAsync(async (name, cancellation) =>
                        {
                            bool alreadyExists = await _context.User.AnyAsync(p => p.Name == name, cancellation);
                            return !alreadyExists;
                        }).WithMessage("El nombre introducido ya existe.");

             RuleFor(p => p.Description).MaximumLength(10000).WithMessage("El campo de descripción es demasiado largo.");

        }
    }
}