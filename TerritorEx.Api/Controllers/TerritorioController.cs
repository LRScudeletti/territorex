using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class TerritorioController : ControllerBase
{
    private readonly ITerritorio _territorio;

    public TerritorioController(ITerritorio territorio)
    {
        _territorio = territorio;
    }

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var territorio = _territorio.RecuperarTodos();
        return Ok(territorio);
    }

    [HttpGet("territorio={territorioId:int}")]
    public IActionResult RecuperarPorId(int territorioId)
    {
        var territorio = _territorio.RecuperarPorId(territorioId);
        return Ok(territorio);
    }

    [HttpGet("nome={territorioNome}")]
    public ActionResult RecuperarPorNome(string territorioNome)
    {
        var territorio = _territorio.RecuperarPorNome(territorioNome);
        return Ok(territorio);
    }

    [HttpGet("pai={territorioPaiId:int}")]
    public IActionResult RecuperarPorPaiId(int territorioPaiId)
    {
        var territorio = _territorio.RecuperarPorPaiId(territorioPaiId);
        return Ok(territorio);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    public IActionResult RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var territorio = _territorio.RecuperarPorNivelTerritorioId(nivelTerritorioId);
        return Ok(territorio);
    }

    [HttpGet("hierarquia/territorio={territorioId:int}")]
    public IActionResult RecuperarHierarquia(int territorioId)
    {
        var territorio = _territorio.RecuperarHierarquia(territorioId);
        return Ok(territorio);
    }
}