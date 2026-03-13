namespace Hope.Domain.Models
{
    public class User(string name, string surname, string email, string phoneNumber, string? address)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = name;
        public string Surname { get; init; } = surname;
        public string Email { get; init; } = email;
        public string PhoneNumber { get; init; } = phoneNumber;
        public string? Address { get; init; } = address;
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;

        // Navigation Properties
        public ICollection<Order> Orders { get; private set; } = [];
    }
}
