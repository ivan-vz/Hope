using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Update;

namespace Hope.Application.Interfaces
{
    public interface IMealService
    {
        public Task<(MealDto?, ValidationResult)> CreateAsync(MealInsertDto dtInsert, CancellationToken ct);
        public Task<MealDto?> GetByIdAsync(Guid id, CancellationToken ct);
        public Task<IReadOnlyList<MealDto>> GetByTagsAsync(IEnumerable<string> tags, CancellationToken ct);
        public Task<IReadOnlyList<MealDto>> GetAllAsync(CancellationToken ct);
        public Task<ValidationResult> DeleteAsync(Guid id, CancellationToken ct);
        public Task<(MealDto?, ValidationResult)> UpdateAsync(MealUpdateDto dtUpdate, CancellationToken ct);
    }
}
