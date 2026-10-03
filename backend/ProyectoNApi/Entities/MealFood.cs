namespace ProyectoNApi.Entities
{
    public class MealFood
    {
        public required int MealId { get; set; }
        public Meal? Meal { get; set; }
        public required int FoodId { get; set; }
        public Food? Food { get; set; }
        public required decimal QuantityInGrams { get; set; }
    }
}