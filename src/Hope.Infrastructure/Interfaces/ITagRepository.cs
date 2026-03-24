using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface ITagRepository
    {
        public Task<IReadOnlyList<Tag>> GetAllTagsAsync(CancellationToken ct);
        public Task<IReadOnlyList<Tag>> GetAllActiveTagsAsync(CancellationToken ct);
        public Task<Tag?> GetByNameAsync(string name, CancellationToken ct);
        public Task<Tag?> ExistsByNameAsync(string name, CancellationToken ct);
        public void Add(Tag tag);
    }
}
