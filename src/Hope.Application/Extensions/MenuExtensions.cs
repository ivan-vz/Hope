using Hope.Application.DTOs.Detail;
using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class MenuExtensions
    {
        public static MenuDto ToDto(this Menu menu)
        {
            return new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Meals = [.. menu.Meals.Select(x => x.ToDto())]
            };
        }
    }
}
