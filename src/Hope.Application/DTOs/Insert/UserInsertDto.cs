namespace Hope.Application.DTOs.Insert
{
    public class UserInsertDto
    {
        public required string Name { get; init; }
        public required string Surname { get; init; }
        public required string Email { get; init; }
        public required string PhoneNumber { get; init; }
        public string? Address { get; init; }
    }
}
