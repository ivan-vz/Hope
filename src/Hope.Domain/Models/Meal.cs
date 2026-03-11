namespace Hope.Domain.Models
{
    public class Meal(string name, string description, decimal price, ICollection<Tag> tags)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;
        public decimal Price { get; private set; } = price;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;

        // Navigation Properties
        public ICollection<Menu> Menu { get; set; } = [];
        public ICollection<Tag> Tags { get; set; } = tags;
    }
}
