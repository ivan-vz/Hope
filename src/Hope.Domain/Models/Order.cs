namespace Hope.Domain.Models
{
    public class Order(decimal total, User user, ICollection<Meal> meals, bool delivery)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public decimal Total { get; init; } = total;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
        public string? DeliverTo { get; init; } = delivery ? user.Address : null;
        public DateTimeOffset? Delivered { get; private set; } = null;

        // Navigation Properties
        public Guid UserId { get; init; } = user.Id;
        public User User { get; init; } = user;

        public ICollection<Meal> Meals { get; init; } = meals;
    }
}
