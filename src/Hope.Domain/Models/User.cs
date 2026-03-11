namespace Hope.Domain.Models
{
    public class User(string name, string email, string surname)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = name;
        public string Surname { get; set; } = surname;
        public string Email { get; init; } = email;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;

        // Navigation Properties
        public ICollection<Order> Orders { get; private set; } = [];
    }
}
