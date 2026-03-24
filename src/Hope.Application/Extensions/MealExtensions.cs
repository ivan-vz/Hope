using Hope.Application.DTOs.Detail;
using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class MealExtensions // Esto es para que el servicio pueda hacer meal.HasTag("tag") sin tener que ensuciar el modelo o el servicio con codigo extra
    {
        public static MealDto ToDto(this Meal meal)
        {
            return new MealDto
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                ImageUrl = meal.ImageUrl,
                Tags = [..meal.Tags.Select(x => x.Name)]
            };
        }
    }
}
