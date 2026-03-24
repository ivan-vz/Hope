namespace Hope.Application.DTOs.Update
{
    public class MealUpdateDto
    {
        public required Guid Id { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public string? ImageUrl { get; init; }
        public ICollection<string>? Tags { get; init; }
    }
}