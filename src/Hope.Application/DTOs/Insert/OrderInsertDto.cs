using Hope.Application.DTOs.Records;

namespace Hope.Application.DTOs.Insert
{
    public class OrderInsertDto
    {
        public required Guid UserId { get; init; }
        public required ICollection<MealItem> Meals { get; init; }
        public required bool Delivery { get; init; }
        public required DateOnly To { get; init; }
    }
}
