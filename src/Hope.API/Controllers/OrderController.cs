using Hope.API.Extensions;
using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Update;
using Hope.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [Authorize]
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetAllByUser(Guid userId, CancellationToken ct) => 
            Ok(await _orderService.GetAllByUserAsync(userId, ct));

        [Authorize]
        [HttpGet("by-date")]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetAllByDate([FromBody] DateOnly date, CancellationToken ct) => 
            Ok(await _orderService.GetAllByDateAsync(date, ct));

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(Guid id, CancellationToken ct)
        {
            var order = await _orderService.GetByIdAsync(id, ct);
            return (order is null) ? NotFound() : Ok(order);
        }

        [Authorize]
        [HttpGet("{id}/update")]
        public async Task<ActionResult<OrderForUpdateDto>> GetForUpdate(Guid id, CancellationToken ct)
        {
            var order = await _orderService.GetForUpdateAsync(id, ct);
            return (order is null) ? NotFound() : Ok(order);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(OrderInsertDto insertDto, CancellationToken ct)
        {
            var (userId, tokenValidation) = User.GetUserId();
            if (!tokenValidation.IsValid) return BadRequest(tokenValidation.ToDictionary());

            var (dt, validation) = await _orderService.CreateAsync(userId, insertDto, ct);
            return (dt is null) ? BadRequest(validation.ToDictionary()) : CreatedAtAction(nameof(GetById), new { id = dt!.Id }, dt);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken ct) => (await _orderService.DeleteAsync(id, ct)).IsValid ? NoContent() : NotFound();

        [Authorize(Roles = "Admin, User")]
        [HttpPut]
        public async Task<ActionResult<OrderDto>> Update(OrderUpdateDto updateDto, CancellationToken ct)
        {
            var (dt, validation) = await _orderService.UpdateAsync(updateDto, ct);
            return (dt is null) ? BadRequest(validation.ToDictionary()) : Ok(dt);
        }
    }
}
