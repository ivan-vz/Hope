using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Login;

namespace Hope.Application.Interfaces
{
    public interface IUserService
    {
        public Task<(LoggedDto? dt, ValidationResult validation)> CreateAsync(UserInsertDto dtInsert, CancellationToken ct);
        public Task<IReadOnlyList<UsertDto>> GetAllAsync (CancellationToken ct);
        public Task<UsertDto?> GetByIdAsync(Guid id);

        public Task<(LoggedDto? dt, ValidationResult validation)> Login(LoginRequest login);
    }
}
