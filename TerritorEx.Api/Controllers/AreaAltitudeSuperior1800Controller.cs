using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaAltitudeSuperior1800Controller : ControllerBase
{
    private readonly IAreaAltitudeSuperior1800 _area;

    public AreaAltitudeSuperior1800Controller(IAreaAltitudeSuperior1800 area)
    {
        _area = area;
    }

    [HttpGet("recuperartodos")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }
}