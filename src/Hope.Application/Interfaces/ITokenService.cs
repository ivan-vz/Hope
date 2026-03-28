using FluentValidation.Results;
using Hope.Domain.Models;

namespace Hope.Application.Interfaces
{
    public interface ITokenService
    {
        public Task<(string?, ValidationResult)> Create(User user);
    }
}
