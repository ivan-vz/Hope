namespace Hope.Domain.Models
{
    public class Tag(string name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = name;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;

        // Navigation Properties
        public ICollection<Meal> Meals { get; set; } = [];
    }
}
