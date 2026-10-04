using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class AnthropometricMeasurement
    {
        [Key]
        public required int MeasurementId { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? FatPercentage { get; set; }
        public decimal? MusclePercentage { get; set; }
        public decimal? Waist { get; set; }
        public decimal? Hip { get; set; }
        public decimal? Wrist { get; set; }
        public decimal? Thigh { get; set; }
        public decimal? Calf { get; set; }
        public decimal? RelaxedArm { get; set; }
        public decimal? ContractedArm { get; set; }
        public decimal? BicipitalSkinfold { get; set; }
        public decimal? TricipitalSkinfold { get; set; }
        public decimal? SubscapularSkinfold { get; set; }
        public decimal? SuprailiacSkinfold { get; set; }
        public decimal? AbdominalSkinfold { get; set; }
        public decimal? SupraspinalSkinfold { get; set; }
        public decimal? FrontThighSkinfold { get; set; }
        public decimal? MedialCalfSkinfold { get; set; }
        public decimal? Observations { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}