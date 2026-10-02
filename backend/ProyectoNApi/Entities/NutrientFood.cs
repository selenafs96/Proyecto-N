namespace ProyectoNApi.Entities
{
    public class NutrientFood
    {
        public required int NutrientId { get; set; }
        public Nutrient? Nutrient { get; set; }
        public required int FoodId { get; set; }
        public Food? Food { get; set; }
        public decimal? QuantityPer100g { get; set; }
    }
}