using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TerritoryController : ControllerBase
{
    private readonly ITerritory _territory;

    public TerritoryController(ITerritory territory)
    {
        _territory = territory;
    }

    [HttpGet("readall")]
    public ActionResult<Territory> ReadAll()
    {
        var territories = _territory.ReadAll();
        return Ok(territories);
    }
}