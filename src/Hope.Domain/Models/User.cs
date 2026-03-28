using Microsoft.AspNetCore.Identity;

namespace Hope.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; init; }
        public string? Surname { get; init; }
        public string? Address { get; init; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset Created { get; init; } = DateTimeOffset.UtcNow;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation Properties
        public ICollection<Order> Orders { get; private set; } = [];

        public User(string name, string? surname, string email, string phoneNumber, string? address)
        {
            Name = name;
            Surname = surname;
            Address = address;

            // Identity
            Email = email;
            PhoneNumber = phoneNumber;
            UserName = email;
        }
    }
}