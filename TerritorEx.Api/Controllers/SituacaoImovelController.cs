using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Controllers;

[ApiController]
[Route("[controller]/recuperar")]
public class SituacaoImovelController : ControllerBase
{
    private readonly ISituacaoImovel _situacaoImovel;

    public SituacaoImovelController(ISituacaoImovel situacaoImovel)
    {
        _situacaoImovel = situacaoImovel;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista as situações de imóveis.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(SituacaoImovel))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Mensagem.MensagemInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Mensagem.MensagemErro))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public ActionResult RecuperarTodos()
    {
        var situacaoImovel = _situacaoImovel.RecuperarTodos();
        return Ok(situacaoImovel);
    }

    [HttpGet("situacao={situacaoImovelId:int}")]
    [SwaggerOperation(Summary = "Carrega os dados da situação informada.")]
    [SwaggerResponse((int)HttpStatusCode.OK, "Requisição realizada com sucesso.", typeof(SituacaoImovel))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Nenhuma área encontrada.", typeof(Mensagem.MensagemInfo))]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ocorreu um erro com a requisição.", typeof(Mensagem.MensagemErro))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor.")]
    public IActionResult RecuperarPorId(int situacaoImovelId)
    {
        var situacaoImovel = _situacaoImovel.RecuperarPorId(situacaoImovelId);
        return Ok(situacaoImovel);
    }
}