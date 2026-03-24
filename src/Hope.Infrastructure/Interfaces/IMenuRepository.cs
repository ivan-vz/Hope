using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IMenuRepository
    {
        public Task<IReadOnlyList<Menu>> GetAllAsync(CancellationToken ct);
        public Task<IReadOnlyList<Menu>> GetAllByDateAsync(DateOnly date, CancellationToken ct);
        public Task<IReadOnlyList<Menu>> GetByTagsAsync(IEnumerable<string> tags, CancellationToken ct);
        public Task<Menu?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<bool> ExistsByName(string name, CancellationToken ct);
        public void Add(Menu menu);
    }
}
