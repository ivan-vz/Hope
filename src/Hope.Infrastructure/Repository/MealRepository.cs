using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    internal class MealRepository(ApplicationDbContext context) : IMealRepository
    {
        // Meals
        public async Task AddAsync(Meal meal) => await context.Meals.AddAsync(meal);

        public async Task<IReadOnlyList<Meal>> GetAllAsync() => await context.Meals.ToListAsync();

        public async Task<Meal?> GetByIdAsync(Guid id) => await context.Meals.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Meal?>> GetByTagsAsync(IEnumerable<string> tags) => await context.Meals
            .Where(x => tags
            .All(tag => x.Tags
            .Any(t => t.Name == tag)))
            .ToListAsync();

        public void UpdateAsync(Meal meal)
        {
            context.Meals.Attach(meal);
            context.Meals.Entry(meal).State = EntityState.Modified;
        }

        // Tags
        public async Task AddTagAsync(Tag tag) => await context.Tags.AddAsync(tag);

        public async Task<IReadOnlyList<Tag>> GetAllTagsAsync() => await context.Tags.ToListAsync();
    }
}
