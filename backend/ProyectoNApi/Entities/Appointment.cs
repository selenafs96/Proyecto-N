using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{

    public enum State
    {
        Scheduled,
        Confirmed,
        Completed,
        Cancelled,
        NoShow
    }

    public enum Format
    {
        InPerson,
        Online
    }

    public enum Type
    {
        Initial,
        FollowUp,
        Specific
    }
    public class Appointment
    {
        [Key]
        public required int AppointmentId { get; set; }
        public required DateTimeOffset AppointmentDateTime { get; set; }
        public required int Duration { get; set; }
        public required State State { get; set; } = State.Scheduled;
        public required Format Format { get; set; } = Format.InPerson;
        public required Type Type { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset? Reminder { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int UserId { get; set; }
        public User? User { get; set; }
    }
}