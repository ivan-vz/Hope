using Hope.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hope.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController(ITagService tagService, CancellationToken ct) : ControllerBase
    {
        private readonly ITagService _tagService = tagService;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<string>>> GetAll() => Ok(await _tagService.GetAllAsync(ct));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<string>>> GetAllActive() => Ok(await _tagService.GetAllActiveAsync(ct));

        [HttpPost]
        public async Task<ActionResult> Create(string name)
        {
            var validation = await _tagService.CreateAsync(name, ct);

            return (validation.IsValid) ? NoContent() : BadRequest(validation.ToDictionary());
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string name)
        {
            var result = await _tagService.DeleteAsync(name, ct);
            return (result.IsValid) ? NoContent() : BadRequest(result.ToDictionary());
        }
    }
}
