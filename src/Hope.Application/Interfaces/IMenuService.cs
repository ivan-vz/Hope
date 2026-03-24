using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Interfaces
{
    public interface IMenuService
    {
        public Task<(MenuDto?, ValidationResult)> CreateAsync(MenuInsertDto dtInsert, CancellationToken ct);
        public Task<IReadOnlyList<MenuDto>> GetAllAsync(CancellationToken ct);
        public Task<IReadOnlyList<MenuDto>> GetAllByDateAsync(DateOnly date, CancellationToken ct);
        public Task<IReadOnlyList<MenuDto>> GetAllByTagsAsync(IEnumerable<string> tags, CancellationToken ct);
        public Task<MenuDto?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<ValidationResult> DeleteAsync(Guid id, CancellationToken ct);
        public Task<(MenuDto?, ValidationResult)> UpdateAsync(MenuUpdateDto dtUpdate, CancellationToken ct);
    }
}
