using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LevelController : ControllerBase
{
    private readonly ILevel _level;

    public LevelController(ILevel level)
    {
        _level = level;
    }

    [HttpGet("readall")]
    public ActionResult ReadAll()
    {
        var level = _level.ReadAll();
        return Ok(level);
    }

    [HttpGet("read/{levelId:int}")]
    public IActionResult ReadById(int levelId)
    {
        var level = _level.ReadById(levelId);
        return Ok(level);
    }
}