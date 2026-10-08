namespace ProyectoNApi.Entities
{

    public enum RestrictionType
    {
        Allergy,
        Intolerance,
        Preference
    }
    // Relationship between Food and Patient
    public class Restriction
    {
        public required int FoodId { get; set; }
        public Food? Food { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required RestrictionType Type { get; set; }
        public string? Observations { get; set; }
    }
}