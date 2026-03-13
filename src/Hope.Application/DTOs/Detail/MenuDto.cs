namespace Hope.Application.DTOs.Detail
{
    public class MenuDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required ICollection<MealDto> Meals { get; init; }
    }
}
