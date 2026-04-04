using FluentValidation.Results;
using Hope.Application.DTOs.Detail;

namespace Hope.Application.Interfaces
{
    public interface ICalendarService
    {
        public Task<(IEnumerable<DayRecord>, ValidationResult)> GetAllByDate(Guid userId, DateOnly date, CancellationToken ct);
    }
}
