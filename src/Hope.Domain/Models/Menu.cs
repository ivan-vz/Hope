namespace Hope.Domain.Models
{
    public class Menu(string name, ICollection<Meal> meals)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;

        // Navigation Properties
        public ICollection<Meal> Meals { get; private set; } = meals;
    }
}
