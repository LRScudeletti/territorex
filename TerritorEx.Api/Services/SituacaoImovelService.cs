using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface ISituacaoImovelService
{
    Task<IEnumerable<SituacaoImovel>> RecuperarTodos();
    Task<IReadOnlyCollection<SituacaoImovel>> RecuperarPorId(int situacaoImovelId);
}
#endregion

#region [ Services ]
public class SituacaoImovelService : ISituacaoImovelService
{
    private readonly ISituacaoImovelRepository _situacaoImovelRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public SituacaoImovelService(ISituacaoImovelRepository situacaoImovelRepository, IStringLocalizer<Resources> localizer)
    {
        _situacaoImovelRepository = situacaoImovelRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<SituacaoImovel>> RecuperarTodos()
    {
        return await _situacaoImovelRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<SituacaoImovel>> RecuperarPorId(int situacaoImovelId)
    {
        var area = await _situacaoImovelRepository.RecuperarPorId(situacaoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["situacao_imovel_nao_encontrada"]);

        return area;
    }
}
#endregion