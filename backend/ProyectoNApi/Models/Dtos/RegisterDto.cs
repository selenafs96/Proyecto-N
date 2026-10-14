using System.ComponentModel.DataAnnotations;

namespace ProyectoNApi.Models.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string? Dni { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }
}