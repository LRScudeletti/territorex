using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class AreaNascenteOlhoDAguaController : ControllerBase
{
    private readonly IAreaNascenteOlhoDAgua _area;

    public AreaNascenteOlhoDAguaController(IAreaNascenteOlhoDAgua area)
    {
        _area = area;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista as áreas com nascentes ou olhos d'água.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaNascenteOlhoDAgua))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Mensagem.MensagemInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Mensagem.MensagemErro))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();
        return Ok(area);
    }

    [HttpGet("territorio={territorioId:int}")]
    [SwaggerOperation(Summary = "Lista as áreas com nascentes ou olhos d'água do território informando.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(AreaNascenteOlhoDAgua))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Mensagem.MensagemInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Mensagem.MensagemErro))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}