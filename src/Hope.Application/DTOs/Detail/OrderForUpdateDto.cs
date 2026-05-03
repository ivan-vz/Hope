using Hope.Application.DTOs.Records;

namespace Hope.Application.DTOs.Detail
{
    public class OrderForUpdateDto
    {
        public bool Delivery { get; set; }
        public string? Address { get; set; }
        public string? Message { get; set; }
        public required ICollection<MealItem> Meals { get; set; }
    }
}
