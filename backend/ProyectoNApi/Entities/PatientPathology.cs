using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class PatientPathology
    {
        [Key]
        public required int PathologyId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}