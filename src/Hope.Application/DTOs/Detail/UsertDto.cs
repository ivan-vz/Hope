namespace Hope.Application.DTOs.Detail
{
    public class UsertDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Surname { get; init; }
        public required string Email { get; init; }
        public required string PhoneNumber { get; init; }
        public string? Address { get; init; }
        public required DateTimeOffset Created { get; init; }
    }
}
