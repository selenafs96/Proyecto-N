using System.ComponentModel.DataAnnotations; 

namespace ProyectoNApi.Entities
{
    public class Patient
    {
        [Key]
        public required int PatientId { get; set; }
        public required string Dni { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateOnly Birthdate { get; set; }
        public required string Genre { get; set; }
        public required string Occupation { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? StreetNumber { get; set; }
        public string? FloorOrDoor { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Province { get; set; }
        public string? Country { get; set; }
        public required string PhysicalActivity { get; set; }
        public required bool AlcoholConsumption { get; set; }
        public required bool TobaccoConsumption { get; set; }
        public required string Approach { get; set; }
        public string? SpecialDiet { get; set; }
        public string? Observations { get; set; }
        public required DateOnly RegisterDate { get; set; }
        public required bool IsActive { get; set; }
        public ICollection<PatientTreatment>? Treatments { get; set; }
        public ICollection<AnthropometricMeasurement>? AnthropometricMeasurements { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        //Relationship table between Patient y User
        public ICollection<PatientUser> PatientUsers { get; set; } = new List<PatientUser>();
        public ICollection<PatientPathology>? PatientPathologies { get; set; }
        public ICollection<NutritionalPlan>? NutritionalPlans { get; set; }
                // Relationship table between Food and Patient
        public ICollection<Restriction> Restrictions { get; set; } = new List<Restriction>();

        //TODO en el validador de Patient, hacer que la lista PatientUsers no pueda estar vacía (siempre tiene que tener un nutricionista asociado)

    }
}