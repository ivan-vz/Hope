namespace Hope.Application.DTOs.Detail
{
    public class UsertDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public required DateTimeOffset Created { get; set; }
    }
}
