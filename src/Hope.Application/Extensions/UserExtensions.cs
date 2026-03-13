using Hope.Application.DTOs.Detail;
using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class UserExtensions
    {
        public static UsertDto ToDto(this User user)
        {
            return new UsertDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Created = user.Created,
            };
        }
    }
}
