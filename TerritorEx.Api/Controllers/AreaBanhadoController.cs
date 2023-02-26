using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AreaBanhadoController : ControllerBase
{
    private readonly IAreaBanhado _area;

    public AreaBanhadoController(IAreaBanhado area)
    {
        _area = area;
    }

    #region [ Documentação RecuperarTodos ]
    [SwaggerOperation(Summary = "swagger_summary_area_banhado")]
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

    #region [ Documentação RecuperarPorTerritorioId ]
    [SwaggerOperation(Summary = "swagger_summary_area_banhado_id")]
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