using FluentValidation;
using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Login;
using Hope.Application.Extensions;
using Hope.Application.Interfaces;
using Hope.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hope.Application.Services
{
    public class UserService(
        UserManager<User> userManager, 
        ITokenService tokenService,
        IValidator<UserInsertDto> insertValidator, 
        IValidator<LoginRequest> loginValidator
    ) : IUserService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IValidator<UserInsertDto> _insertValidator = insertValidator;
        private readonly IValidator<LoginRequest> _loginValidator = loginValidator;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<(LoggedDto? dt, ValidationResult validation)> CreateAsync(UserInsertDto dtInsert, CancellationToken ct)
        {
            var validation = await _insertValidator.ValidateAsync(dtInsert, ct);

            if (!validation.IsValid) return (null, validation);

            var instance = new User(dtInsert.Name, dtInsert.Surname, dtInsert.Email, dtInsert.PhoneNumber, dtInsert.Address);
            var result = await _userManager.CreateAsync(instance, dtInsert.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    validation.Errors.Add(new ValidationFailure("Identity", error.Description));
                }
                return (null, validation);
            }

            await _userManager.AddToRoleAsync(instance, "User");

            var (token, tokenValidation) = await _tokenService.Create(instance);
            if (!tokenValidation.IsValid) return (null, tokenValidation);

            return (instance.ToLoggedDto(token!), validation);
        }

        public async Task<IReadOnlyList<UsertDto>> GetAllAsync(CancellationToken ct) => [.. (await _userManager.Users.ToListAsync(ct)).Select(x => x.ToDto())];

        public async Task<UsertDto?> GetByIdAsync(Guid id) => (await _userManager.FindByIdAsync(id.ToString()))?.ToDto();

        public async Task<(LoggedDto? dt, ValidationResult validation)> Login(LoginRequest login)
        {
            var validation = await _loginValidator.ValidateAsync(login);
            if (!validation.IsValid) return (null, validation);

            var user = await _userManager.FindByEmailAsync(login.Identifier);
            if (user is null)
            {
                validation.Errors.Add(new ValidationFailure("User", "Invalid data"));
                return (null, validation);
            }

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
            {
                validation.Errors.Add(new ValidationFailure("User", "Invalid data"));
                return (null, validation);
            }

            var (token, tokenValidation) = await _tokenService.Create(user);
            if (!tokenValidation.IsValid) return (null, tokenValidation);

            return (user.ToLoggedDto(token!), validation);
        }
    }
}
