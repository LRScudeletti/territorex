using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaBordaChapadaController : ControllerBase
{
    private readonly IAreaBordaChapada _area;

    public AreaBordaChapadaController(IAreaBordaChapada area)
    {
        _area = area;
    }

    [HttpGet("recuperartodos")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [HttpGet("recuperarterritorioid/{territorioId:int}")]
    public IActionResult RecuperarPorId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}