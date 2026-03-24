using Hope.Application.DTOs.Detail;
using Hope.Application.DTOs.Insert;
using Hope.Application.DTOs.Update;
using Hope.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController(IMenuService menuService, CancellationToken ct) : ControllerBase
    {
        private readonly IMenuService _menuService = menuService;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAll() => Ok(await _menuService.GetAllAsync(ct));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAllByDate([FromBody] DateOnly date) => Ok(await _menuService.GetAllByDateAsync(date, ct));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuDto>>> GetAllByTags([FromBody] ICollection<string> tags) => Ok(await _menuService.GetAllByTagsAsync(tags, ct));

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDto>> GetById(Guid id)
        {
            var menu = Ok(await _menuService.GetByIdAsync(id, ct));

            return (menu is null) ? NotFound() : Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult<MenuDto>> Create(MenuInsertDto dtInsert)
        {
            var (dt, validation) = await _menuService.CreateAsync(dtInsert, ct);

            return (dt is null) ? BadRequest(validation.ToDictionary()) : CreatedAtAction(nameof(GetById), new { id =  dt!.Id }, dt);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) => (await _menuService.DeleteAsync(id, ct)).IsValid ? NoContent() : NotFound();

        [HttpPut]
        public async Task<ActionResult<MenuDto>> Update(MenuUpdateDto updateDto)
        {
            var (dt, validation) = await _menuService.UpdateAsync(updateDto, ct);

            return (dt is null) ? BadRequest(validation.ToDictionary()) : Ok(dt);
        }
    }
}
