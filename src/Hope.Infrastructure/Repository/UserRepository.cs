using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<IReadOnlyList<User>> GetAllAsync() => await context.Users.ToListAsync();
        public async Task<User?> GetByIdAsync(Guid id) => await context.Users.SingleOrDefaultAsync(x => x.Id == id);
        public async Task AddAsync(User user) => await context.Users.AddAsync(user);
    }
}
