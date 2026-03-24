namespace Hope.Application.DTOs.Detail
{
    public class MealDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required decimal Price { get; init; }
        public string? ImageUrl { get; init; }
        public ICollection<string>? Tags { get; init; }
    }
}
