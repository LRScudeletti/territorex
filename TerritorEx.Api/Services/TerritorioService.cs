using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface ITerritorioService
{
    Task<IEnumerable<Territorio>> RecuperarTodos();
    Task<IReadOnlyCollection<Territorio>> RecuperarPorId(int territorioId);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorNome(string territorioNome);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorTerritorioSuperiorId(int territorioSuperiotId);
    Task<IReadOnlyCollection<Territorio>> RecuperarPorNivelTerritorioId(int nivelTerritorioId);
    Task<TerritorioHierarquia> RecuperarHierarquia(int territorioId);
}
#endregion

#region [ Services ]
public class TerritorioService : ITerritorioService
{
    private readonly ITerritorioRepository _territorioRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public TerritorioService(ITerritorioRepository territorioRepository, IStringLocalizer<Resources> localizer)
    {
        _territorioRepository = territorioRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<Territorio>> RecuperarTodos()
    {
        return await _territorioRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorId(int territorioId)
    {
        var area = await _territorioRepository.RecuperarPorId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["territorio_nao_encontrada"]);

        return area;
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorNome(string territorioNome)
    {
        var area = await _territorioRepository.RecuperarPorNome(territorioNome);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["territorio_nao_encontrada"]);

        return area;
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorTerritorioSuperiorId(int territorioSuperiotId)
    {
        var area = await _territorioRepository.RecuperarPorTerritorioSuperiorId(territorioSuperiotId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["territorio_nao_encontrada"]);

        return area;
    }

    public async Task<IReadOnlyCollection<Territorio>> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var area = await _territorioRepository.RecuperarPorNivelId(nivelTerritorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["territorio_nao_encontrada"]);

        return area;
    }

    public async Task<TerritorioHierarquia> RecuperarHierarquia(int territorioId)
    {
        var area = await _territorioRepository.RecuperarHierarquia(territorioId);

        return area ?? throw new KeyNotFoundException(_localizer["territorio_nao_encontrada"]);
    }
}
#endregion