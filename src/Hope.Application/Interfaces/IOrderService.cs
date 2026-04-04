using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Records;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<(OrderDto?, ValidationResult)> CreateAsync(OrderInsertDto dtInsert, CancellationToken ct);
        public Task<IReadOnlyList<OrderDto>> GetAllByUserAsync(Guid userId, CancellationToken ct);
        public Task<IReadOnlyList<OrderDto>> GetAllByDateAsync(DateOnly date, CancellationToken ct);
        public Task<IReadOnlyList<OrderTo>> GetAllByMonthAsync(Guid userId, DateOnly date, CancellationToken ct);
        public Task<OrderDto?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<ValidationResult> DeleteAsync(Guid id, CancellationToken ct);
        public Task<(OrderDto?, ValidationResult)> UpdateAsync(OrderUpdateDto dtUpdate, CancellationToken ct);
    }
}
