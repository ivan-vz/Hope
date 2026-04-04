using Hope.Domain.Models;

namespace Hope.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IReadOnlyList<Order>> GetAllByUserAsync(Guid userId, CancellationToken ct);
        public Task<IReadOnlyList<Order>> GetAllByDateAsync(DateOnly date, CancellationToken ct);
        public Task<IReadOnlyList<Order>> GetAllByMonthAsync(Guid userId, DateOnly date, CancellationToken ct);
        public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);
        public void Add(Order order);
    }
}