using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

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

    [HttpGet]
    [SwaggerOperation(Summary = "Lista as áreas com altitude superior a 1.800 metros.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaAltitudeSuperior1800))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [SwaggerOperation(Summary = "Lista as áreas com altitude superior a 1.800 metros do território informado.")]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaAltitudeSuperior1800))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    [HttpGet("territorio={territorioId:int}")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}