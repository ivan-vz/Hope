using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken ct) => await context.Users.ToListAsync(ct);
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct) => await context.Users.SingleOrDefaultAsync(x => x.Id == id, ct);
        public void Add(User user) => context.Users.Add(user);

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct) => await context.Users.AnyAsync(x => x.Email == email, ct);

        public async Task<bool> ExistsByPhoneNumberAsync(string number, CancellationToken ct) => await context.Users.AnyAsync(x => x.PhoneNumber == number, ct);
    }
}
