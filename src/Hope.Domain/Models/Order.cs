using Hope.Domain.Models.Auxiliary;

namespace Hope.Domain.Models
{
    public class Order
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public decimal Total { get; set; }
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
        public string Address { get; set; } = null!;
        public DateOnly To { get; init; }
        public DateTimeOffset? LastUpdate { get; set; }
        public string? Message { get; set; } = null!;
        public bool IsCancelled { get; set; } = false;


        // Navigation Properties
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<OrderMeal> Meals { get; set; } = [];

        private Order() {}

        public Order(decimal total, Guid userId, string address, DateOnly to, string? message)
        {
            Total = total;
            UserId = userId;
            Address = address;
            To = to;
            Message = message;
        }
    }
}
