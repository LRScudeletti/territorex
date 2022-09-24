using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TerritorioController : ControllerBase
{
    private readonly ITerritorio _territorio;

    public TerritorioController(ITerritorio territorio)
    {
        _territorio = territorio;
    }

    [HttpGet("recuperartodos")]
    public ActionResult RecuperarTodos()
    {
        var territorio = _territorio.RecuperarTodos();
        return Ok(territorio);
    }

    [HttpGet("recuperar/{territorioId:int}")]
    public IActionResult RecuperarPorId(int territorioId)
    {
        var territorio = _territorio.RecuperarPorId(territorioId);
        return Ok(territorio);
    }

    [HttpGet("recuperarnome/{territorioNome}")]
    public ActionResult RecuperarPorNome(string territorioNome)
    {
        var territorio = _territorio.RecuperarPorNome(territorioNome);
        return Ok(territorio);
    }

    [HttpGet("recuperarpai/{territorioPaiId:int}")]
    public IActionResult RecuperarPorPaiId(int territorioPaiId)
    {
        var territorio = _territorio.RecuperarPorPaiId(territorioPaiId);
        return Ok(territorio);
    }

    [HttpGet("recuperarnivel/{nivelId:int}")]
    public IActionResult RecuperarPorNivel(int nivelId)
    {
        var territorio = _territorio.RecuperarPorNivelId(nivelId);
        return Ok(territorio);
    }

    [HttpGet("recuperarhierarquia/{territorioId:int}")]
    public IActionResult RecuperarHierarquia(int territorioId)
    {
        var territorio = _territorio.RecuperarHierarquia(territorioId);
        return Ok(territorio);
    }
}