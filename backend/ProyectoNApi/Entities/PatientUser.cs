namespace ProyectoNApi.Entities
{
    public class PatientUser
    {
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int UserId { get; set; }
        public User? User { get; set; }
        public required bool IsPrimary { get; set; }
    }
}