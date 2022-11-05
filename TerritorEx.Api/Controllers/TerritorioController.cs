using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Error;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class TerritorioController : ControllerBase
{
    private readonly ITerritorio _territorio;

    public TerritorioController(ITerritorio territorio)
    {
        _territorio = territorio;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista os territórios.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var territorio = _territorio.RecuperarTodos();
        return Ok(territorio);
    }

    [HttpGet("territorio={territorioId:int}")]
    [SwaggerOperation(Summary = "Carrega as informações do território informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorId(int territorioId)
    {
        var territorio = _territorio.RecuperarPorId(territorioId);
        return Ok(territorio);
    }

    [HttpGet("nome={territorioNome}")]
    [SwaggerOperation(Summary = "Lista os territórios de acordo com o nome informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarPorNome(string territorioNome)
    {
        var territorio = _territorio.RecuperarPorNome(territorioNome);
        return Ok(territorio);
    }

    [HttpGet("pai={territorioSuperiorId:int}")]
    [SwaggerOperation(Summary = "Lista os territórios de acordo com o território superior informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorTerritorioSuperiorId(int territorioSuperiorId)
    {
        var territorio = _territorio.RecuperarPorTerritorioSuperiorId(territorioSuperiorId);
        return Ok(territorio);
    }

    [HttpGet("nivel={nivelTerritorioId:int}")]
    [SwaggerOperation(Summary = "Lista os territórios de acordo com o nível informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var territorio = _territorio.RecuperarPorNivelTerritorioId(nivelTerritorioId);
        return Ok(territorio);
    }

    [HttpGet("hierarquia/territorio={territorioId:int}")]
    [SwaggerOperation(Summary = "Lista o hierarquia do território informado.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(Territorio))]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Nenhuma área encontrada.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Message))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarHierarquia(int territorioId)
    {
        var territorio = _territorio.RecuperarHierarquia(territorioId);
        return Ok(territorio);
    }
}