using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class SituacaoImovelController : ControllerBase
{
    private readonly ISituacaoImovel _situacaoImovel;

    public SituacaoImovelController(ISituacaoImovel situacaoImovel)
    {
        _situacaoImovel = situacaoImovel;
    }

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var situacaoImovel = _situacaoImovel.RecuperarTodos();
        return Ok(situacaoImovel);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    public IActionResult RecuperarPorId(int situacaoImovelId)
    {
        var situacaoImovel = _situacaoImovel.RecuperarPorId(situacaoImovelId);
        return Ok(situacaoImovel);
    }
}