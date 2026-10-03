using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class PatientPathology
    {
        [Key]
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int PathologyId { get; set; }
        public Pathology? Pathology { get; set; }
        public DateOnly? DiagnosedDate { get; set; }
        public string? Notes { get; set; }

    }
}