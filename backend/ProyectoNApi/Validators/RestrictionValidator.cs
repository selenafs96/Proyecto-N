using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class RestrictionValidator : AbstractValidator<Restriction>
    {
        public RestrictionValidator() {
            RuleFor(r => r.Type).IsInEnum().WithMessage("Tipo de restricción no válida. El tipo solo puede ser Alergia, Intolerancia o Preferencia.");
            
            RuleFor(p => p.Observations).MaximumLength(5000).WithMessage("El campo de observaciones es demasiado largo.");
        }
    }
}
