using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaImovelController : ControllerBase
{
    private readonly IAreaImovel _area;

    public AreaImovelController(IAreaImovel area)
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

    [HttpGet("imovel={imovelId}")]
    public IActionResult RecuperarPorImovelId(string imovelId)
    {
        var area = _area.RecuperarPorImovelId(imovelId);
        return Ok(area);
    }

    [HttpGet("tipo={tipoImovelId:int}")]
    public IActionResult RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = _area.RecuperarPorTipoImovelId(tipoImovelId);
        return Ok(area);
    }

    [HttpGet("situacao={situacaoImovelId:int}")]
    public IActionResult RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = _area.RecuperarPorSituacaoImovelId(situacaoImovelId);
        return Ok(area);
    }
}