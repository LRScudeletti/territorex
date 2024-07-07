﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaConsolidadaController(IAreaConsolidadaService areaConsolidadaService) : ControllerBase
{
    #region [ Documentação Swagger RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_consolidada")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaConsolidada))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet]
    public async Task<ActionResult> RecuperarTodos()
    {
        var area = await areaConsolidadaService.RecuperarTodos();
        return Ok(area);
    }

    #region [ Documentação Swagger RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_consolidada_id")]
    [SwaggerResponse((int)HttpStatusCode.OK, "swagger_response_200", typeof(AreaConsolidada))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "swagger_response_400", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "swagger_response_404", typeof(Mensagem))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "swagger_response_500", typeof(Mensagem))]
    #endregion

    [HttpGet("territorio={territorioId:int}")]
    public async Task<IActionResult> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await areaConsolidadaService.RecuperarPorTerritorioId(territorioId);
        return Ok(area);
    }
}