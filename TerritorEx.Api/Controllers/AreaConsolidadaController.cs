using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaConsolidadaController : ControllerBase
{
    private readonly IAreaConsolidada _area;

    public AreaConsolidadaController(IAreaConsolidada area)
    {
        _area = area;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista as áreas consolidadas.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [HttpGet("territorio={territorioId:int}")]
    [SwaggerOperation(Summary = "Lista as áreas consolidadas do território informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}