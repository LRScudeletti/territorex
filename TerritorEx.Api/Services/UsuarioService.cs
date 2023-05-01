using AutoMapper;
using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models.Usuario;
using TerritorEx.Api.Repositories;
using static BCrypt.Net.BCrypt;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IUsuarioService
{
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
    private readonly UsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<Resources> _localizer;

    public UsuarioService(UsuarioRepository usuarioRepository, IMapper mapper, IStringLocalizer<Resources> localizer)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task Criar(CriarUsuario criarUsuario)
    {
        if (await _usuarioRepository.RecuperarPorEmail(criarUsuario.Email) != null)
            throw new AppException("User with the email '" + criarUsuario.Email + "' already exists");

        var usuario = _mapper.Map<Usuario>(criarUsuario);

        // Criptografa a senha
        usuario.PasswordHash = HashPassword(criarUsuario.Password);

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

        var emailChanged = !string.IsNullOrEmpty(atualizarUsuario.Email) && usuario.Email != atualizarUsuario.Email;
       
        if (emailChanged && await _usuarioRepository.RecuperarPorEmail(atualizarUsuario.Email!) != null)
            throw new AppException("User with the email '" + atualizarUsuario.Email + "' already exists");

        if (!string.IsNullOrEmpty(atualizarUsuario.Password))
            usuario.PasswordHash = HashPassword(atualizarUsuario.Password);

        _mapper.Map(atualizarUsuario, usuario);

        await _usuarioRepository.Atualizar(usuario);
    }

    public async Task Remover(int usuarioId)
    {
        await _usuarioRepository.Remover(usuarioId);
    }
}
#endregion