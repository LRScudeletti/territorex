using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Models;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TerritorioController : ControllerBase
{
    private readonly ITerritorioService _territorioService;

    public TerritorioController(ITerritorioService territorioService)
    {
        _territorioService = territorioService;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_territorio")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _territorioService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorId ]
    [SwaggerOperation(Summary = "swagger_summary_territorio_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<IActionResult> RecuperarPorId(int territorioId)
    {
        var area = await _territorioService.RecuperarPorId(territorioId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorNome ]
    [SwaggerOperation(Summary = "swagger_summary_territorio_nome")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("nome={territorioNome}")]
    public async Task<IActionResult> RecuperarPorNome(string territorioNome)
    {
        var area = await _territorioService.RecuperarPorNome(territorioNome);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioSuperiorId ]
    [SwaggerOperation(Summary = "swagger_summary_territorio_superior")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("superior={territorioSuperiorId:int}")]
    public async Task<IActionResult> RecuperarPorTerritorioSuperiorId(int territorioSuperiorId)
    {
        var area = await _territorioService.RecuperarPorTerritorioSuperiorId(territorioSuperiorId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorNivelTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_territorio_nivel")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("nivel={nivelTerritorioId:int}")]
    public async Task<IActionResult> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var area = await _territorioService.RecuperarPorNivelTerritorioId(nivelTerritorioId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarHierarquia ]
    [SwaggerOperation(Summary = "swagger_summary_territorio_hierarquia")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(TerritorioHierarquia))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("hierarquia={territorioId:int}")]
    public async Task<IActionResult> RecuperarHierarquia(int territorioId)
    {
        var area = await _territorioService.RecuperarHierarquia(territorioId);
        return Ok(area);
    }
}