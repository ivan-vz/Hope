using Hope.Domain.Models;
using Hope.Infrastructure.Data;
using Hope.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hope.Infrastructure.Repository
{
    internal class OrderRepository(ApplicationDbContext context) : IOrderRepository
    {
        public async Task AddAsync(Order order) => await context.Orders.AddAsync(order);

        public async Task<IReadOnlyList<Order>> GetAllByDateAsync(DateOnly date) => await context.Orders.Where(x => x.To == date).ToListAsync();

        public async Task<IReadOnlyList<Order>> GetAllByUserAsync(Guid userId) => await context.Orders.Where(x => x.UserId == userId).ToListAsync();

        public async Task<Order?> GetByIdAsync(Guid id) => await context.Orders.SingleOrDefaultAsync(x => x.Id == id);

        public void UpdateAsync(Order order)
        {
            context.Orders.Attach(order);
            context.Orders.Entry(order).State = EntityState.Modified;
        }
    }
}
