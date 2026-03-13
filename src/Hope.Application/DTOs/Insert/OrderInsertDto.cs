namespace Hope.Application.DTOs.Insert
{
    public class OrderInsertDto
    {
        public required decimal Total { get; init; }
        public required Guid UserId { get; init; }
        public required ICollection<Guid> Meals { get; init; }
        public required bool Delivery { get; init; }
    }
}
