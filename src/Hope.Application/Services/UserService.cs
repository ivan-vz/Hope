using FluentValidation;
using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.Extensions;
using Hope.Application.Interfaces;
using Hope.Domain.Models;
using Hope.Infrastructure.Interfaces;

namespace Hope.Application.Services
{
    public class UserService(IUnitOfWork uow, IValidator<UserInsertDto> validator) : IUserService
    {
        private readonly IUnitOfWork _uow = uow;
        private readonly IValidator<UserInsertDto> _validator = validator;

        public async Task<(UsertDto? dt, ValidationResult validation)> CreateAsync(UserInsertDto dtInsert, CancellationToken ct)
        {
            var validation = await _validator.ValidateAsync(dtInsert, ct);

            if (!validation.IsValid) return (null, validation);

            var instance = new User(dtInsert.Name, dtInsert.Surname, dtInsert.Email, dtInsert.PhoneNumber, dtInsert.Address);

            _uow.UserRepository.Add(instance);
            await _uow.Complete();

            return (instance.ToDto(), validation);
        }

        public async Task<IReadOnlyList<UsertDto>> GetAllAsync(CancellationToken ct) => [.. (await _uow.UserRepository.GetAllAsync(ct)).Select(x => x.ToDto())];

        public async Task<UsertDto?> GetByIdAsync(Guid id, CancellationToken ct) => (await _uow.UserRepository.GetByIdAsync(id, ct))?.ToDto();
    }
}
