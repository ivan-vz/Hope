using FluentValidation.Results;
using System.Security.Claims;

namespace Hope.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static (Guid, ValidationResult) GetUserId(this ClaimsPrincipal user)
        {
            var validation = new ValidationResult();
            var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id is null) 
            {
                validation.Errors.Add(new ValidationFailure("User", "Cannot find user id in token"));
                return (Guid.Empty, validation);
            }

            return (Guid.Parse(id), validation);
        }
    }
}
