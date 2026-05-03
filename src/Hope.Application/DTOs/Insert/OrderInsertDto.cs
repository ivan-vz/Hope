using Hope.Application.DTOs.Records;

namespace Hope.Application.DTOs.Insert
{
    public class OrderInsertDto
    {
        public required ICollection<MealItem> Meals { get; init; }
        public required bool Delivery { get; init; }
        public required DateOnly To { get; init; }
        public string? Address  { get; set; }
        public string? Message { get; set; }
    }
}
