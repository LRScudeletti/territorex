using AutoMapper;
using TerritorEx.Api.Authorization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Models.Usuario;
using TerritorEx.Api.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IUsuarioService
{
    AutenticarResponse Autenticar(AutenticarRequest autenticarRequest);
    Task Criar(CriarUsuario criarUsuario);
    Task<IEnumerable<Usuario>> RecuperarTodos();
    Task<Usuario> RecuperarPorId(int usuarioId);
    Task<Usuario> RecuperarPorEmail(string email);
    Task Atualizar(int usuarioId, AtualizarUsuario atualizarUsuario);
    Task Remover(int usuarioId);
}
#endregion

#region [ Services ]
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IJwtUtils jwtUtils, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AutenticarResponse Autenticar(AutenticarRequest autenticarRequest)
    {
        var usuario =  _usuarioRepository.RecuperarPorEmail(autenticarRequest.Email);

        if (usuario == null || !BCryptNet.Verify(autenticarRequest.Senha, usuario.SenhaHash))
            throw new AppException("Username or password is incorrect");

        var response = _mapper.Map<AutenticarResponse>(usuario);
        response.Token = _jwtUtils.GenerateToken(usuario);
        return response;
    }

    public async Task Criar(CriarUsuario criarUsuario)
    {
        if (await _usuarioRepository.RecuperarPorEmail(criarUsuario.Email!) != null)
            throw new AppException("User with the email '" + criarUsuario.Email + "' already exists");

        var usuario = _mapper.Map<Usuario>(criarUsuario);

        usuario.SenhaHash = BCryptNet.HashPassword(criarUsuario.Senha);

        await _usuarioRepository.Criar(usuario);
    }

    public async Task<IEnumerable<Usuario>> RecuperarTodos()
    {
        return await _usuarioRepository.RecuperarTodos();
    }

    public async Task<Usuario> RecuperarPorId(int usuarioId)
    {
        var usuario = await _usuarioRepository.RecuperarPorId(usuarioId);

        return usuario ?? throw new KeyNotFoundException("User not found");
    }

    public async Task<Usuario> RecuperarPorEmail(string email)
    {
        var usuario = await _usuarioRepository.RecuperarPorEmail(email);

        return usuario ?? throw new KeyNotFoundException("User not found");
    }

    public async Task Atualizar(int usuarioId, AtualizarUsuario atualizarUsuario)
    {
        var usuario = await _usuarioRepository.RecuperarPorId(usuarioId) ?? throw new KeyNotFoundException("User not found");

        var email = !string.IsNullOrEmpty(atualizarUsuario.Email) && usuario.Email != atualizarUsuario.Email;
        if (email && await _usuarioRepository.RecuperarPorEmail(atualizarUsuario.Email!) != null)
            throw new AppException("User with the email '" + atualizarUsuario.Email + "' already exists");

        if (!string.IsNullOrEmpty(atualizarUsuario.Senha))
            usuario.SenhaHash = BCryptNet.HashPassword(atualizarUsuario.Senha);

        _mapper.Map(atualizarUsuario, usuario);

        await _usuarioRepository.Atualizar(usuario);
    }

    public async Task Remover(int usuarioId)
    {
        await _usuarioRepository.Remover(usuarioId);
    }
}
#endregion