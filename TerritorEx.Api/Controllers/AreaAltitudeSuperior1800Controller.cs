using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Interfaces;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaAltitudeSuperior1800Controller : ControllerBase
{
    private readonly IAreaAltitudeSuperior1800 _area;

    public AreaAltitudeSuperior1800Controller(IAreaAltitudeSuperior1800 area)
    {
        _area = area;
    }

    /// <summary>
    /// Lista áreas com altitude superior a 1800 metros.
    /// </summary>
    /// <remarks>
    /// Exemplo:
    /// 
    ///     [ 
    ///      {
    ///       "areaId": 1,
    ///       "territorioId": 5100102,
    ///       "sicarId": 1241435,
    ///       "descricao": "Manguezal",
    ///       "areaHectare": 1.51817264092565
    ///      }
    ///     ]
    /// 
    /// </remarks>
    /// <returns>Teste</returns>
    /// <response code="200">Requisição realizada com sucedida.</response>
    /// <response code="400">Erro no servidor.</response>  
    /// <response code="404">Área não encontrada.</response>
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
}