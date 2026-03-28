namespace Hope.Application.DTOs.Login
{
    public class LoggedDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Email { get; init; }
        public string? ImageUrl { get; init; }
        public required string Token { get; init; }
    }
}
