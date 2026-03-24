namespace Hope.Domain.Models
{
    public class Meal(string name, string description, decimal price)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public decimal Price { get; set; } = price;
        public string? ImageUrl { get; set; } = null;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; } = false;

        // Navigation Properties
        public ICollection<Menu> Menu { get; set; } = [];
        public ICollection<Tag> Tags { get; set; } = [];
    }
}