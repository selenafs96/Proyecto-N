using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public enum TreatmentType
    {
        Medication,
        Supplement
    }
    public class Treatment
    {
       [Key]
       public required int TreatmentId { get; set; }
       public required string Name { get; set; }
       public required TreatmentType Type { get; set; }
       public required string Dose { get; set; }
       public required string Frequency { get; set; }
       public required int PatientId { get; set; }
       public Patient? Patient { get; set; }
    }
}