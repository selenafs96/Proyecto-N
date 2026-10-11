using ProyectoNApi.Entities;

namespace ProyectoNApi.Models.Dtos
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public IEnumerable<object>? Errors { get; set; }
        public User? User { get; set; }
    }
}