namespace ProyectoNApi.Entities
{
    public class Pathology
    {
        public required int PathologyId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        //Relationship table between Patient and Pathology
        public ICollection<PatientPathology> PatientPathology { get; set; } = new List<PatientPathology>();
    }
}