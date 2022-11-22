using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class SituacaoImovelService : ISituacaoImovel
{
    private readonly IStringLocalizer<Resource> _localizer;

    public SituacaoImovelService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<SituacaoImovel> RecuperarTodos()
    {
        var situacaoImovel = SituacaoImovelRepository.RecuperarTodos();

        if (!situacaoImovel.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return situacaoImovel;
    }

    public SituacaoImovel RecuperarPorId(int tipoImovelId)
    {
        var situacaoImovel = SituacaoImovelRepository.RecuperarPorId(tipoImovelId);

        if (situacaoImovel == null)
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return situacaoImovel;
    }
}