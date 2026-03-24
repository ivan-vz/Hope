using Hope.Application.DTOs.Records;

namespace Hope.Application.DTOs.Update
{
    public class OrderUpdateDto
    {
        public required Guid Id { get; init; }
        public bool Delivery { get; init; }
        public ICollection<MealItem> Meals { get; init; } = [];
    }
}
