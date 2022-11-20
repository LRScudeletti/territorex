using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaDeclividadeMaior45Controller : ControllerBase
{
    private readonly IAreaDeclividadeMaior45 _area;

    public AreaDeclividadeMaior45Controller(IAreaDeclividadeMaior45 area)
    {
        _area = area;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista as áreas com declividade maior que 45 graus.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaDeclividadeMaior45))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [HttpGet("territorio={territorioId:int}")]
    [SwaggerOperation(Summary = "Lista as áreas com declividade maior que 45 graus do território informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaDeclividadeMaior45))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}