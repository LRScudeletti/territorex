using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TerritorEx.Api.Authorization;
using TerritorEx.Api.Models.Usuario;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private IMapper _mapper;

    public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("autenticar")]
    public IActionResult Autenticar(AutenticarRequest autenticareRequest)
    {
        var response = _usuarioService.Autenticar(autenticareRequest);
        return Ok(response);
    }
}