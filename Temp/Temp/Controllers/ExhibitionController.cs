using Microsoft.AspNetCore.Mvc;
using Temp.DTOs;
using Temp.Services;

namespace Temp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ExhibitionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddExhibition([FromBody] AddExhibitionDTO dto)
    {
        await _dbService.AddExhibitionAsync(dto);
        return Created(); 
    }
}