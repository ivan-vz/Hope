using Hope.Application.DTOs.Detail;
using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class MealExtensions // Esto es para que el servicio pueda hacer meal.HasTag("tag") sin tener que ensuciar el modelo o el servicio con codigo extra
    {
        public static bool HasTag(this Meal meal, string tag) => meal.Tags.Any(x => x.Name == tag);

        public static IQueryable WithTag(this IQueryable<Meal> query, string tag) => query.Where(x => x.Tags.Any(t => t.Name == tag));

        public static MealDto ToDto(this Meal meal)
        {
            return new MealDto
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                Price = meal.Price,
                ImageUrl = meal.ImageUrl
            };
        }
    }
}
