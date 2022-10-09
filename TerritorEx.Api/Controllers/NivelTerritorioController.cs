using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NivelTerritorioController : ControllerBase
{
    private readonly INivelTerritorio _nivelTerritorio;

    public NivelTerritorioController(INivelTerritorio nivelTerritorio)
    {
        _nivelTerritorio = nivelTerritorio;
    }

    [HttpGet("recuperartodos")]
    public ActionResult RecuperarTodos()
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarTodos();
        return Ok(nivelTerritorio);
    }

    [HttpGet("recuperar/{nivelTerritorioId:int}")]
    public IActionResult RecuperarPorId(int nivelTerritorioId)
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarPorId(nivelTerritorioId);
        return Ok(nivelTerritorio);
    }
}