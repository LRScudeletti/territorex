using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NivelTerritorioController(INivelTerritorioService nivelTerritorioService) : ControllerBase
{
    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_nivel_territorio")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(NivelTerritorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await nivelTerritorioService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorId ]
    [SwaggerOperation(Summary = "swagger_summary_nivel_territorio_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(NivelTerritorio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={niveTerritorioId:int}")]
    public async Task<IActionResult> RecuperarPorId(int niveTerritorioId)
    {
        var area = await nivelTerritorioService.RecuperarPorId(niveTerritorioId);
        return Ok(area);
    }
}