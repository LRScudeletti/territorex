using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class TipoImovelService : ITipoImovel
{
    private readonly IStringLocalizer<Resource> _localizer;

    public TipoImovelService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<TipoImovel> RecuperarTodos()
    {
        var tipoImovel = TipoImovelRepository.RecuperarTodos();

        if (!tipoImovel.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return tipoImovel;
    }

    public TipoImovel RecuperarPorId(int tipoImovelId)
    {
        var tipoImovel = TipoImovelRepository.RecuperarPorId(tipoImovelId);

        if (tipoImovel == null)
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return tipoImovel;
    }
}