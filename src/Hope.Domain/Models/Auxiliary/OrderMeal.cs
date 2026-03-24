namespace Hope.Domain.Models.Auxiliary
{
    public class OrderMeal
    {
        public Guid OrderId { get; init; }
        public Guid MealId { get; init; }
        public int Quantity { get; set; }

        // Navigation properites
        public Order Order { get; init; } = null!;
        public Meal Meal { get; init; } = null!;
    }
}
