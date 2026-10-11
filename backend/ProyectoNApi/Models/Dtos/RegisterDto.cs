using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public required string Dni { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }
}