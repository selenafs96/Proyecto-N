namespace ProyectoNApi.Validators;

using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator() {
        RuleFor(u => u.Dni).NotEmpty().WithMessage("El DNI es obligatorio.")
        .Must(BeAValidDni).WithMessage("El DNI introducido no es válido.");

        RuleFor(u => u.Name).NotEmpty().WithMessage("El nombre no puede estar vacío.")
        .MaximumLength(50).WithMessage("El nombre no puede contener más de 50 caracteres.");

        RuleFor(u => u.LastName).NotEmpty().WithMessage("El apellido no puede estar vacío.")
        .MaximumLength(100).WithMessage("El apellido no puede contener más de 100 caracteres.");

        RuleFor(u => u.Email).NotEmpty().WithMessage("El email no puede estar vacío.")
        .EmailAddress().WithMessage("El formato del correo electrónico no es válido");

        RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("El teléfono no puede estar vacío.")
        // Validates international phone numbers (E.164 standard: 2-15 digits, optional '+' prefix, no spaces/hyphens)
        .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("El formato del teléfono no es válido.");

        RuleFor(u => u.PhotoUrl).MaximumLength(2048).WithMessage("URL demasiado larga.");

        RuleFor(u => u.Role).NotEmpty().WithMessage("El rol  no puede quedar vacío");
    }

    /// <summary>
    /// Validates a spanish DNI using the official algorithm.
    /// </summary>
    /// <param name="dni">Text string containing the DNI to be validated (8 digits and 1 letter).</param>
    /// <returns>true if the format is correct, false if it's not.</returns>
    private static bool BeAValidDni(string dni)
    {
        if (string.IsNullOrWhiteSpace(dni)) return false;

        dni = dni.ToUpper().Trim();
        if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}[A-Z]$")) return false;

        string letterSet = "TRWAGMYFPDXBNJZSQVHLCKE";
        int number = int.Parse(dni.Substring(0,8));
        char calculatedLetter = letterSet[number % 23];

        return calculatedLetter == dni[8];
    }
}

