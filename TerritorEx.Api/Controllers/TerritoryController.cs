using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

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
    public ActionResult ReadAll()
    {
        var territory = _territory.ReadAll();
        return Ok(territory);
    }

    [HttpGet("read/{territoryId:int}")]
    public IActionResult ReadById(int territoryId)
    {
        var territory = _territory.ReadById(territoryId);
        return Ok(territory);
    }

    [HttpGet("read/containsname/{territoryName}")]
    public ActionResult ReadByName(string territoryName)
    {
        var territory = _territory.ReadByName(territoryName);
        return Ok(territory);
    }

    [HttpGet("read/parent/{territoryParentId:int}")]
    public IActionResult ReadByTerritoryParentId(int territoryParentId)
    {
        var territory = _territory.ReadByParentId(territoryParentId);
        return Ok(territory);
    }

    [HttpGet("read/level/{levelId:int}")]
    public IActionResult ReadByLevelId(int levelId)
    {
        var territory = _territory.ReadByLevelId(levelId);
        return Ok(territory);
    }

    [HttpGet("read/hierarchy/{territoryId:int}")]
    public IActionResult ReadHierarchy(int territoryId)
    {
        var territory = _territory.ReadHierarchy(territoryId);
        return Ok(territory);
    }
}