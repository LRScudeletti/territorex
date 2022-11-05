using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

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
    [SwaggerOperation(Summary = "Lista os tipos de imóveis.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(TipoImovel))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var tipoImovel = _tipoImovel.RecuperarTodos();
        return Ok(tipoImovel);
    }

    [HttpGet("tipo={tipoImovelId:int}")]
    [SwaggerOperation(Summary = "Carrega os dados do tipo informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(TipoImovel))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorId(int tipoImovelId)
    {
        var tipoImovel = _tipoImovel.RecuperarPorId(tipoImovelId);
        return Ok(tipoImovel);
    }
}