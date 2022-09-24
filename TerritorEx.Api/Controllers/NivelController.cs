using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NivelController : ControllerBase
{
    private readonly INivel _nivel;

    public NivelController(INivel nivel)
    {
        _nivel = nivel;
    }

    [HttpGet("recuperartodos")]
    public ActionResult RecuperarTodos()
    {
        var nivel = _nivel.RecuperarTodos();
        return Ok(nivel);
    }

    [HttpGet("recuperar/{nivelId:int}")]
    public IActionResult RecuperarPorId(int nivelId)
    {
        var nivel = _nivel.RecuperarPorId(nivelId);
        return Ok(nivel);
    }
}