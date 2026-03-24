using FluentValidation.Results;

namespace Hope.Application.Interfaces
{
    public interface ITagService
    {
        public Task<ValidationResult> CreateAsync(string tagName, CancellationToken ct);
        public Task<IReadOnlyList<string>> GetAllAsync(CancellationToken ct);
        public Task<IReadOnlyList<string>> GetAllActiveAsync(CancellationToken ct);
        public Task<ValidationResult> DeleteAsync(string name, CancellationToken ct);
    }
}
