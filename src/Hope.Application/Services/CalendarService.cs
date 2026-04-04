using FluentValidation.Results;
using Hope.Application.DTOs.Detail;
using Hope.Application.Interfaces;

namespace Hope.Application.Services
{
    public class CalendarService(IUserService userService, IOrderService orderService) : ICalendarService
    {
        private readonly IUserService _userService = userService;
        private readonly IOrderService _orderService = orderService;

        public async Task<(IEnumerable<DayRecord>, ValidationResult)> GetAllByDate(Guid userId, DateOnly date, CancellationToken ct)
        {
            var validation = new ValidationResult();

            var user = await _userService.GetByIdAsync(userId);
            if (user is null)
            {
                validation.Errors.Add(new ValidationFailure("User", "User not found"));
                return ([], validation);
            }

            var ordersTo = await _orderService.GetAllByMonthAsync(userId, date, ct);

            var from = new DateOnly(date.Year, date.Month, 1);
            var to = from.AddMonths(1).AddDays(-1);
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var days = new List<DayRecord>();

            for (var d = from; d <= to; d = d.AddDays(1))
            {
                var order = ordersTo.FirstOrDefault(x => x.To == d);
                var active = d >= today.AddDays(2);
                days.Add( new DayRecord(d, active, order?.Id) );
            }

            return (days, validation);
        }
    }
}
