namespace Hope.Application.DTOs.Update
{
    public class MenuUpdateDto
    {
        public required Guid Id { get; init; }
        public ICollection<DateOnly> AvailableMonths { get; set; } = [];
        public ICollection<Guid> Meals { get; set; } = [];
    }
}
