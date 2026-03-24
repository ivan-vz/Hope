using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct);
        public Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
        public Task<bool> ExistsByPhoneNumberAsync(string number, CancellationToken ct);
        public void Add(User user);
    }
}
