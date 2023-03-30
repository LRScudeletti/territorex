using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaNascenteOlhoDAguaController : ControllerBase
{
    private readonly IAreaNascenteOlhoDAguaService _areaNascenteOlhoDAguaService;

    public AreaNascenteOlhoDAguaController(IAreaNascenteOlhoDAguaService areaNascenteOlhoDAguaService)
    {
        _areaNascenteOlhoDAguaService = areaNascenteOlhoDAguaService;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_nascente_olho_dagua")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaManguezal))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _areaNascenteOlhoDAguaService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_nascente_olho_dagua_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaManguezal))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<ActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaNascenteOlhoDAguaService.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}