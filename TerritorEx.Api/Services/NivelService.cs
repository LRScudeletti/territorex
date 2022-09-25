using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Nivel;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Services;

public class NivelService : INivel
{
    public IEnumerable<Nivel> RecuperarTodos()
    {
        var nivel = NivelRepository.RecuperarTodos();

        if (nivel == null)
            throw new KeyNotFoundException(Properties.Resources.NivelNaoEncontrado);

        return nivel;
    }

    public Nivel RecuperarPorId(int nivelId)
    {
        var nivel = NivelRepository.RecuperarPorId(nivelId);

        if (nivel == null)
            throw new KeyNotFoundException(Properties.Resources.NivelNaoEncontrado);

        return nivel;
    }
}