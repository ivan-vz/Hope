using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IMenuRepository
    {
        public Task<IReadOnlyList<Menu>> GetAllAsync();
        public Task<IReadOnlyList<Menu>> GetAllByDateAsync(DateOnly date);
        public Task<IReadOnlyList<Menu>> GetByTagsAsync(IEnumerable<string> tags);
        public Task<Menu?> GetByIdAsync(Guid id);
        public Task AddAsync(Menu menu);
        public void UpdateAsync(Menu menu);
    }
}
