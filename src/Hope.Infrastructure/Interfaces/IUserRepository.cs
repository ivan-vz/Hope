using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<IReadOnlyList<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(Guid id);
        public Task AddAsync(User user);
    }
}
