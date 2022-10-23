using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class TipoImovelController : ControllerBase
{
    private readonly ITipoImovel _tipoImovel;

    public TipoImovelController(ITipoImovel tipoImovel)
    {
        _tipoImovel = tipoImovel;
    }

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var tipoImovel = _tipoImovel.RecuperarTodos();
        return Ok(tipoImovel);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    public IActionResult RecuperarPorId(int tipoImovelId)
    {
        var tipoImovel = _tipoImovel.RecuperarPorId(tipoImovelId);
        return Ok(tipoImovel);
    }
}