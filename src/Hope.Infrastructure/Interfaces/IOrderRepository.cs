using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IReadOnlyList<Order>> GetAllByUserAsync(Guid userId);
        public Task<IReadOnlyList<Order>> GetAllByDateAsync(DateOnly date);
        public Task<Order?> GetByIdAsync(Guid id);
        public Task AddAsync(Order order);
        public void UpdateAsync(Order order);
    }
}
