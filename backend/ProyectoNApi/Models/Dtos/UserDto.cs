
namespace ProyectoNApi.Models.Dtos
{
    public class UserDto
    {
        public required string Dni { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }
}