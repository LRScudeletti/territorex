using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Models;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaDeclividadeMaior45Controller : ControllerBase
{
    private readonly IAreaDeclividadeMaior45Service _areaDeclividadeMaior45Service;

    public AreaDeclividadeMaior45Controller(IAreaDeclividadeMaior45Service areaDeclividadeMaior45Service)
    {
        _areaDeclividadeMaior45Service = areaDeclividadeMaior45Service;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_declividade_maior_45")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _areaDeclividadeMaior45Service.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_declividade_maior_45_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<ActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaDeclividadeMaior45Service.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}