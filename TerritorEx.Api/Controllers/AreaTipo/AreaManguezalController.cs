using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces.Area;

namespace TerritorEx.Api.Controllers.Area;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaManguezalController : ControllerBase
{
    private readonly IAreaManguezal _area;

    public AreaManguezalController(IAreaManguezal area)
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