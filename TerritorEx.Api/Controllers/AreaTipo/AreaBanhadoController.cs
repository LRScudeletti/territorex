using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces.Area;

namespace TerritorEx.Api.Controllers.Area;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaBanhadoController : ControllerBase
{
    private readonly IAreaBanhado _area;

    public AreaBanhadoController(IAreaBanhado area)
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