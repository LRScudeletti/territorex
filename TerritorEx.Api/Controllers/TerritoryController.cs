namespace TerritorEx.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models.Territory;
using Services;

[ApiController]
[Route("[controller]")]
public class TerritoryController : ControllerBase
{
    private readonly ITerritoryService _territoryService;

    public TerritoryController(ITerritoryService territoryService)
    {
        _territoryService = territoryService;
    }

    [HttpPost("create")]
    public IActionResult Create(TerritoryCreateModel territoryCreateModel)
    {
        _territoryService.Create(territoryCreateModel);
        return Ok(new { message = Properties.Resources.TerritoryCreatedSuccessfully });
    }

    [HttpGet("readall")]
    public IActionResult ReadAll()
    {
        var territories = _territoryService.ReadAll();
        return Ok(territories);
    }

    [HttpGet("read/{territoryId:int}")]
    public IActionResult ReadByTerritoryId(int territoryId)
    {
        var territory = _territoryService.ReadByTerritoryId(territoryId);
        return Ok(territory);
    }

    [HttpGet("read/containsname/{territoryName}")]
    public IActionResult ReadByContainsName(string territoryName)
    {
        var territory = _territoryService.ReadByContainsName(territoryName);
        return Ok(territory);
    }

    [HttpGet("read/parent/{parentId:int}")]
    public IActionResult ReadByParentId(int parentId)
    {
        var territory = _territoryService.ReadByParentId(parentId);
        return Ok(territory);
    }

    [HttpGet("read/level/{levelId:int}")]
    public IActionResult ReadByLevelId(int levelId)
    {
        var territory = _territoryService.ReadByLevelId(levelId);
        return Ok(territory);
    }

    [HttpPut("update")]
    public IActionResult Update(TerritoryUpdateModel territoryUpdateModel)
    {
        _territoryService.Update(territoryUpdateModel);
        return Ok(new { message = Properties.Resources.TerritoryUpdatedSuccessfully });
    }

    [HttpDelete("delete/{territoryId:int}")]
    public IActionResult Delete(int territoryId)
    {
        _territoryService.Delete(territoryId);
        return Ok(new { message = "User deleted" });
    }
}