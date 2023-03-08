using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaImovelController : ControllerBase
{
    private readonly IAreaImovel _area;

    public AreaImovelController(IAreaImovel area)
    {
        _area = area;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500")]
    #endregion

    [HttpGet]
    public ActionResult RecuperarTodos()
    {
        var area = _area.RecuperarTodos();

        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500")]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public IActionResult RecuperarPorTerritorioId(int territorioId)
    {
        var area = _area.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_imovel")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500")]
    #endregion

    [HttpGet("imovel={imovelId}")]
    public IActionResult RecuperarPorImovelId(string imovelId)
    {
        var area = _area.RecuperarPorImovelId(imovelId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTipoImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_tipo")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500")]
    #endregion

    [HttpGet("tipo={tipoImovelId:int}")]
    public IActionResult RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = _area.RecuperarPorTipoImovelId(tipoImovelId);
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorSituacaoImovelId ]
    [SwaggerOperation(Summary = "swagger_summary_area_imovel_situacao")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(Area))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Message.MessageError))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Message.MessageInfo))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500")]
    #endregion

    [HttpGet("situacao={situacaoImovelId:int}")]
    public IActionResult RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = _area.RecuperarPorSituacaoImovelId(situacaoImovelId);
        return Ok(area);
    }
}