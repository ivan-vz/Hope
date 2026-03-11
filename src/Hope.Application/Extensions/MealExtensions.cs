using Hope.Domain.Models;

namespace Hope.Application.Extensions
{
    public static class MealExtensions // Esto es para que el servicio pueda hacer meal.HasTag("tag") sin tener que ensuciar el modelo o el servicio con codigo extra
    {
        public static bool HasTag(this Meal meal, string tag) => meal.Tags.Any(x => x.Name == tag);

        public static IQueryable WithTag(this IQueryable<Meal> query, string tag) => query.Where(x => x.Tags.Any(t => t.Name == tag));
    }
}
