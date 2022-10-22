using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces.AreaTerritorial;

namespace TerritorEx.Api.Controllers.AreaTerritorial;

[ApiController]
[Route("[controller]/recuperar")]
public class NivelTerritorioController : ControllerBase
{
    private readonly INivelTerritorio _nivelTerritorio;

    public NivelTerritorioController(INivelTerritorio nivelTerritorio)
    {
        _nivelTerritorio = nivelTerritorio;
    }

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarTodos();
        return Ok(nivelTerritorio);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    public IActionResult RecuperarPorId(int nivelTerritorioId)
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarPorId(nivelTerritorioId);
        return Ok(nivelTerritorio);
    }
}