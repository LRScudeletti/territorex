using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaImovelController(IAreaImovelService areaImovelService) : ControllerBase
{
    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await areaImovelService.RecuperarTodos();

        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_territorio")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<IActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await areaImovelService.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("imovel={imovelId}")]
    public async Task<IActionResult> RecuperarPorImovelId(string imovelId)
    {
        var area = await areaImovelService.RecuperarPorImovelId(imovelId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTipoImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_tipo")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("tipo={tipoImovelId:int}")]
    public async Task<IActionResult> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = await areaImovelService.RecuperarPorTipoImovelId(tipoImovelId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorSituacaoImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_situacao")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaImovel))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("situacao={situacaoImovelId:int}")]
    public async Task<IActionResult> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = await areaImovelService.RecuperarPorSituacaoImovelId(situacaoImovelId);
        return Ok(area);
    }
}