using Hope.API.Extensions;
using Hope.Application.DTOs.Detail;
using Hope.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController(ICalendarService calendarService) : ControllerBase
    {

        private readonly ICalendarService _calendarService = calendarService;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayRecord>>> GetByMonth([FromQuery] DateOnly date, CancellationToken ct)
        {
            var (userId, tokenValidation) = User.GetUserId();
            if (!tokenValidation.IsValid) return BadRequest(tokenValidation.ToDictionary());

            var (days, validation) = await _calendarService.GetAllByDate(userId, date, ct);

            return (!validation.IsValid) ? BadRequest(validation.ToDictionary()) : Ok(days);
        }
    }
}
