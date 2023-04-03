using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface ITipoImovelService
{
    Task<IEnumerable<TipoImovel>> RecuperarTodos();
    Task<IReadOnlyCollection<TipoImovel>> RecuperarPorId(int tipoImovelId);
}
#endregion

#region [ Services ]
public class TipoImovelService : ITipoImovelService
{
    private readonly ITipoImovelRepository _tipoImovelRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public TipoImovelService(ITipoImovelRepository tipoImovelRepository, IStringLocalizer<Resources> localizer)
    {
        _tipoImovelRepository = tipoImovelRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<TipoImovel>> RecuperarTodos()
    {
        return await _tipoImovelRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<TipoImovel>> RecuperarPorId(int tipoImovelId)
    {
        var area = await _tipoImovelRepository.RecuperarPorId(tipoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["tipo_imovel_nao_encontrada"]);

        return area;
    }
}
#endregion