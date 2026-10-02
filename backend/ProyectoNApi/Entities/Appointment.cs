using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class Appointment
    {
        [Key]
        public required int AppointmentId { get; set; }
        public required DateTime DateTime { get; set; }
        public required int Duration { get; set; }
        public required string State { get; set; }
        public string? Format { get; set; }
        public string? Type { get; set; }
        public string? Notes { get; set; }
        public DateTime Reminder { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int UserId { get; set; }
        public User? User { get; set; }
    }
}