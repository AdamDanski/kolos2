using Temp.Services;
using Microsoft.AspNetCore.Mvc;
using Temp.Exceptions;

namespace Temp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GalleriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public GalleriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> AddExhibition([FromRoute] int id)
    {
        try
        {
            return Ok(await _dbService.GetGalleryExhibitionsAsync(id));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}