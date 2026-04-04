namespace Hope.Application.DTOs.Detail
{
    public record DayRecord(DateOnly Date, bool Active, Guid? OrderId);
}
