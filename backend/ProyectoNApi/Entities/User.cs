using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Entities
{
    public class User
    {
        [Key]
        public required int UserId { get; set; }
        public required string Dni { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
