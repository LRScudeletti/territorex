﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaDeclividadeMaior45Controller : ControllerBase
{
    private readonly IAreaDeclividadeMaior45 _area;

    public AreaDeclividadeMaior45Controller(IAreaDeclividadeMaior45 area)
    {
        _area = area;
    }

    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_declividade_maior_45")]
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
    [SwaggerOperation(Summary = "swagger_summary_area_declividade_maior_45_id")]
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
}