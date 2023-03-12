using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaBordaChapadaController : ControllerBase
{
    private readonly IAreaBordaChapadaService _areaBordaChapadaService;

    public AreaBordaChapadaController(IAreaBordaChapadaService areaBordaChapadaService)
    {
        _areaBordaChapadaService = areaBordaChapadaService;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_borda_chapada")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaBordaChapada))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _areaBordaChapadaService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_borda_chapada_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaBordaChapada))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<ActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaBordaChapadaService.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}