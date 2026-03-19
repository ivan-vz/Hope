using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IMealRepository
    {
        // Meals
        public Task<IReadOnlyList<Meal>> GetAllAsync();
        public Task<IReadOnlyList<Meal?>> GetByTagsAsync(IEnumerable<string> tags);
        public Task<Meal?> GetByIdAsync(Guid id);
        public Task AddAsync(Meal meal);
        public void UpdateAsync(Meal meal);

        // Tags
        public Task<IReadOnlyList<Tag>> GetAllTagsAsync();
        public Task AddTagAsync(Tag tag);
    }
}
