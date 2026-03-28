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
    public class MenuController(IMenuService menuService) : ControllerBase
    {
        private readonly IMenuService _menuService = menuService;

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAll(CancellationToken ct) => Ok(await _menuService.GetAllAsync(ct));

        [Authorize]
        [HttpGet("by-date")]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAllByDate([FromQuery] DateOnly date, CancellationToken ct) => 
            Ok(await _menuService.GetAllByDateAsync(date, ct));

        [Authorize]
        [HttpGet("by-tags")]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAllByTags([FromBody] ICollection<string> tags, CancellationToken ct) => 
            Ok(await _menuService.GetAllByTagsAsync(tags, ct));

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDto>> GetById(Guid id, CancellationToken ct)
        {
            var menu = Ok(await _menuService.GetByIdAsync(id, ct));

            return (menu is null) ? NotFound() : Ok(menu);
        }

        [Authorize(Roles = "Admin, Chef")]
        [HttpPost]
        public async Task<ActionResult<MenuDto>> Create(MenuInsertDto dtInsert, CancellationToken ct)
        {
            var (dt, validation) = await _menuService.CreateAsync(dtInsert, ct);

            return (dt is null) ? BadRequest(validation.ToDictionary()) : CreatedAtAction(nameof(GetById), new { id =  dt!.Id }, dt);
        }

        [Authorize(Roles = "Admin, Chef")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken ct) => (await _menuService.DeleteAsync(id, ct)).IsValid ? NoContent() : NotFound();

        [Authorize(Roles = "Admin, Chef")]
        [HttpPut]
        public async Task<ActionResult<MenuDto>> Update(MenuUpdateDto updateDto, CancellationToken ct)
        {
            var (dt, validation) = await _menuService.UpdateAsync(updateDto, ct);

            return (dt is null) ? BadRequest(validation.ToDictionary()) : Ok(dt);
        }
    }
}
