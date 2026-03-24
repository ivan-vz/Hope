using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IMealRepository
    {
        // Meals
        public Task<IReadOnlyList<Meal>> GetAllAsync(CancellationToken ct);
        public Task<IReadOnlyList<Meal>> GetByTagsAsync(IEnumerable<string> tags, CancellationToken ct);
        public Task<Meal?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<bool> ExistsByName(string name, CancellationToken ct);
        public void Add(Meal meal);
    }
}
