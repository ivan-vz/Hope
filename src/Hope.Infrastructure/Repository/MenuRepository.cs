using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    public class MenuRepository(ApplicationDbContext context) : IMenuRepository
    {
        public async Task AddAsync(Menu menu) => await context.Menus.AddAsync(menu);

        public async Task<IReadOnlyList<Menu>> GetAllAsync() => await context.Menus.ToListAsync();

        public async Task<IReadOnlyList<Menu>> GetAllByDateAsync(DateOnly date) => await context.Menus.Where(x => x.AvailableMonths.Contains(date)).ToListAsync();

        public async Task<IReadOnlyList<Menu>> GetByTagsAsync(IEnumerable<string> tags) => await context.Menus
            .Where(x => x.Meals
            .Any(m => m.Tags
            .Any(t => tags.Contains(t.Name))))
            .ToListAsync();

        public async Task<Menu?> GetByIdAsync(Guid id) => await context.Menus.SingleOrDefaultAsync(x => x.Id == id);

        public void UpdateAsync(Menu menu)
        {
            context.Menus.Attach(menu);
            context.Menus.Entry(menu).State = EntityState.Modified;
        }
    }
}
