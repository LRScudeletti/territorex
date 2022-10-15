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

    [HttpGet("recuperarimovelid/{imovelId}")]
    public IActionResult RecuperarPorTipoImovelId(string imovelId)
    {
        var area = _area.RecuperarPorImovelId(imovelId);
        return Ok(area);
    }

    [HttpGet("recuperartipoimovelid/{tipoImovelId:int}")]
    public IActionResult RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = _area.RecuperarPorTipoImovelId(tipoImovelId);
        return Ok(area);
    }

    [HttpGet("recuperarsituacaoimovelid/{situacaoImovelId:int}")]
    public IActionResult RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = _area.RecuperarPorSituacaoImovelId(situacaoImovelId);
        return Ok(area);
    }
}