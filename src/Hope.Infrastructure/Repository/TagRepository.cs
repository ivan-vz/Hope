using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    internal class TagRepository(ApplicationDbContext context) : ITagRepository
    {
        public async Task<Tag?> GetByNameAsync(string name, CancellationToken ct)
        {
            var normalized = name.Trim().ToLowerInvariant();
            return await context.Tags.Where(x => x.IsDeleted == false).SingleOrDefaultAsync(x => x.Name == name, ct);
        }

        public void Add(Tag tag) => context.Tags.Add(tag);

        public async Task<Tag?> ExistsByNameAsync(string name, CancellationToken ct)
        {
            var normalized = name.Trim().ToLowerInvariant();
            return await context.Tags.SingleOrDefaultAsync(x => x.Name == name, ct);
        }

        public async Task<IReadOnlyList<Tag>> GetAllTagsAsync(CancellationToken ct) => await context.Tags.ToListAsync(ct);
        
        public async Task<IReadOnlyList<Tag>> GetAllActiveTagsAsync(CancellationToken ct) => await context.Tags.Where(x => x.IsDeleted == false).ToListAsync(ct);
    }
}
