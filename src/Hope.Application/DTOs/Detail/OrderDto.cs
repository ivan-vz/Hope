namespace Hope.Application.DTOs.Detail
{
    public class OrderDto
    {
        public required Guid Id { get; init; }
        public required decimal Total { get; init; }
        public required DateTimeOffset Created { get; init; }
        public required string? Address { get; set; }
        public string? Message { get; set; }
        public required UsertDto User { get; init; }
        public required ICollection<MealDto> Meals { get; init; }
    }
}
