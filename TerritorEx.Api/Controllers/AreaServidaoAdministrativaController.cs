using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaServidaoAdministrativaController : ControllerBase
{
    private readonly IAreaServidaoAdministrativa _area;

    public AreaServidaoAdministrativaController(IAreaServidaoAdministrativa area)
    {
        _area = area;
    }

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [HttpGet("territorio={territorioId:int}")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}