namespace Hope.Application.DTOs.Insert
{
    public class MenuInsertDto
    {
        public required string Name { get; init; }
        public required ICollection<Guid> Meals { get; init; }
    }
}
