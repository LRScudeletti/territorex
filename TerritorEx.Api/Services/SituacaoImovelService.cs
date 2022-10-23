using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class SituacaoImovelService : ISituacaoImovel
{
    public IReadOnlyList<SituacaoImovel> RecuperarTodos()
    {
        var situacaoImovel = SituacaoImovelRepository.RecuperarTodos();

        if (!situacaoImovel.Any())
            throw new KeyNotFoundException(Properties.Resources.SituacaoImovelnaoEncontrada);

        return situacaoImovel;
    }

    public SituacaoImovel RecuperarPorId(int tipoImovelId)
    {
        var situacaoImovel = SituacaoImovelRepository.RecuperarPorId(tipoImovelId);

        if (situacaoImovel == null)
            throw new KeyNotFoundException(Properties.Resources.SituacaoImovelnaoEncontrada);

        return situacaoImovel;
    }
}