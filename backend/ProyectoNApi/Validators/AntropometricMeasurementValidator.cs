using FluentValidation;

using ProyectoNApi.Entities;

namespace ProyectoNApi.Validators
{
    public class AnthropometricMeasurementValidator : AbstractValidator<AnthropometricMeasurement>
    {
        public AnthropometricMeasurementValidator() {
            RuleFor(a => a.Date).NotEmpty().WithMessage("La fecha no puede estar vacía.")
            .LessThan(DateOnly.FromDateTime(DateTime.UtcNow.ToLocalTime())).WithMessage("La fecha no puede ser futura.");

            RuleFor(a => a.Weight).InclusiveBetween(1, 400).WithMessage("El peso debe estar entre 1 y 400 kg.").When(a => a.Weight.HasValue);

            RuleFor(a => a.Height).InclusiveBetween(20, 250).WithMessage("La altura debe estar entre 20 y 250 cm.").When(a => a.Height.HasValue);
            
            RuleFor(a => a.FatPercentage).InclusiveBetween(2, 70).WithMessage("El porcentaje de grasa corporal debe estar entre 2% y 70%.").When(a => a.FatPercentage.HasValue);
            
            RuleFor(a => a.MusclePercentage).InclusiveBetween(2, 70).WithMessage("El porcentaje de masa muscular debe estar entre 2% y 70%.").When(a => a.MusclePercentage.HasValue);

            RuleFor(a => a.Waist).InclusiveBetween(20,250).WithMessage("Medidas de circunferencia de cintura no válidas.").When(a => a.Waist.HasValue);

            RuleFor(a => a.Hip).InclusiveBetween(20,250).WithMessage("Medidas de circunferencia de cadera no válidas.").When(a => a.Hip.HasValue);

            RuleFor(a => a.Wrist).InclusiveBetween(5,30).WithMessage("Medidas de circunferencia de muñeca no válidas.").When(a => a.Wrist.HasValue);

            RuleFor(a => a.Thigh).InclusiveBetween(15,120).WithMessage("Medidas de circunferencia de muslo no válidas.").When(a => a.Thigh.HasValue);

            RuleFor(a => a.Calf).InclusiveBetween(15,100).WithMessage("Medidas de circunferencia de pantorrilla no válidas.").When(a => a.Calf.HasValue);

            RuleFor(a => a.RelaxedArm).InclusiveBetween(10,100).WithMessage("Medidas de circunferencia de brazo relajado no válidas.").When(a => a.RelaxedArm.HasValue);

            RuleFor(a => a.ContractedArm).InclusiveBetween(10,100).WithMessage("Medidas de circunferencia de brazo contraído no válidas.").When(a => a.ContractedArm.HasValue);

            RuleFor(a => a.BicipitalSkinfold).InclusiveBetween(1,60).WithMessage("Medidas de pliegue bicipital no válidas.").When(a => a.BicipitalSkinfold.HasValue);
            
            RuleFor(a => a.TricipitalSkinfold).InclusiveBetween(1,60).WithMessage("Medidas de pliegue tricipital no válidas.").When(a => a.TricipitalSkinfold.HasValue);
            
            RuleFor(a => a.SubscapularSkinfold).InclusiveBetween(2,70).WithMessage("Medidas de pliegue subescapular no válidas.").When(a => a.SubscapularSkinfold.HasValue);
            
            RuleFor(a => a.SuprailiacSkinfold).InclusiveBetween(2,80).WithMessage("Medidas de pliegue suprailíaco no válidas.").When(a => a.SuprailiacSkinfold.HasValue);
            
            RuleFor(a => a.AbdominalSkinfold).InclusiveBetween(2,80).WithMessage("Medidas de pliegue abdominal no válidas.").When(a => a.AbdominalSkinfold.HasValue);
            
            RuleFor(a => a.SupraspinalSkinfold).InclusiveBetween(2,80).WithMessage("Medidas de pliegue supraespinal no válidas.").When(a => a.SupraspinalSkinfold.HasValue);
            
            RuleFor(a => a.FrontThighSkinfold).InclusiveBetween(2,80).WithMessage("Medidas de pliegue del muslo anterior no válidas.").When(a => a.FrontThighSkinfold.HasValue);
            
            RuleFor(a => a.MedialCalfSkinfold).InclusiveBetween(2,50).WithMessage("Medidas de pliegue de la pantorrilla medial no válidas.").When(a => a.MedialCalfSkinfold.HasValue);
            
            RuleFor(a => a.Observations).MaximumLength(5000).WithMessage("El campo de observaciones es demasiado largo.");

        }
    }
}