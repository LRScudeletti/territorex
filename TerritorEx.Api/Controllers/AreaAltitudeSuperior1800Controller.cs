using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Models;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaAltitudeSuperior1800Controller : ControllerBase
{
    private readonly IAreaAltitudeSuperior1800Service _areaAltitudeSuperior1800Service;

    public AreaAltitudeSuperior1800Controller(IAreaAltitudeSuperior1800Service areaAltitudeSuperior1800Service)
    {
        _areaAltitudeSuperior1800Service = areaAltitudeSuperior1800Service;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_altitude_superior_1800")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaAltitudeSuperior1800Model))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _areaAltitudeSuperior1800Service.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_altitude_superior_1800_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaAltitudeSuperior1800Model))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<IActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaAltitudeSuperior1800Service.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}