using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProyectoNApi.Entities
{
    public class User : IdentityUser<int>
    {
        // IdentityUser already has Email, PasswordHash, PhoneNumber, Username...
        public string? Dni { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? PhotoUrl { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        //Relationship table between Patient y User
        public ICollection<PatientUser> PatientUsers { get; set; } = new List<PatientUser>();
        public ICollection<NutritionalPlan>? NutritionalPlans { get; set; }

    }
}
