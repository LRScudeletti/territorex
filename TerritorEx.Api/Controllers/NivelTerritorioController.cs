using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class NivelTerritorioController : ControllerBase
{
    private readonly INivelTerritorio _nivelTerritorio;

    public NivelTerritorioController(INivelTerritorio nivelTerritorio)
    {
        _nivelTerritorio = nivelTerritorio;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista os níveis de território.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(NivelTerritorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarTodos();
        return Ok(nivelTerritorio);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    [SwaggerOperation(Summary = "Carrega informações do nível informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(NivelTerritorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorId(int nivelTerritorioId)
    {
        var nivelTerritorio = _nivelTerritorio.RecuperarPorId(nivelTerritorioId);
        return Ok(nivelTerritorio);
    }
}