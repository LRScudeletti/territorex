using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaPreservacaoPermanenteController : ControllerBase
{
    private readonly IAreaPreservacaoPermanenteService _areaPreservacaoPermanenteService;

    public AreaPreservacaoPermanenteController(IAreaPreservacaoPermanenteService areaPreservacaoPermanenteService)
    {
        _areaPreservacaoPermanenteService = areaPreservacaoPermanenteService;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_preservacao_permanente")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaPousio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _areaPreservacaoPermanenteService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_preservacao_permanente_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaPousio))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<IActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaPreservacaoPermanenteService.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}