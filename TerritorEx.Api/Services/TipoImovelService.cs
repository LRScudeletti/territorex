using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class TipoImovelService : ITipoImovel
{
    public IReadOnlyList<TipoImovel> RecuperarTodos()
    {
        var tipoImovel = TipoImovelRepository.RecuperarTodos();

        if (!tipoImovel.Any())
            throw new KeyNotFoundException(Properties.Resources.TipoImovelnaoEncontrado);

        return tipoImovel;
    }

    public TipoImovel RecuperarPorId(int tipoImovelId)
    {
        var tipoImovel = TipoImovelRepository.RecuperarPorId(tipoImovelId);

        if (tipoImovel == null)
            throw new KeyNotFoundException(Properties.Resources.TipoImovelnaoEncontrado);

        return tipoImovel;
    }
}