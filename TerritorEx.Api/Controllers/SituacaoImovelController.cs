using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SituacaoImovelController : ControllerBase
{
    private readonly ISituacaoImovelService _situacaoImovelService;

    public SituacaoImovelController(ISituacaoImovelService situacaoImovelService)
    {
        _situacaoImovelService = situacaoImovelService;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_situacao_imovel")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(SituacaoImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await _situacaoImovelService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorId ]
    [SwaggerOperation(Summary = "swagger_summary_situacao_imovel_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(SituacaoImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={situacaoImovelId:int}")]
    public async Task<IActionResult> RecuperarPorId(int situacaoImovelId)
    {
        var area = await _situacaoImovelService.RecuperarPorId(situacaoImovelId);
        return Ok(area);
    }
}