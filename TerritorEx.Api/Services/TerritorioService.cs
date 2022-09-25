using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Territorio;
using TerritorEx.Api.Repository;

namespace TerritorEx.Api.Services;

public class TerritorioService : ITerritorio
{
    public IEnumerable<Territorio> RecuperarTodos()
    {
        var territorio = TerritorioRepository.RecuperarTodos();

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public Territorio RecuperarPorId(int territorioId)
    {
        var territorio = TerritorioRepository.RecuperarPorId(territorioId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IEnumerable<Territorio> RecuperarPorNome(string territorioNome)
    {
        var territorio = TerritorioRepository.RecuperarPorNome(territorioNome);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IEnumerable<Territorio> RecuperarPorPaiId(int territorioPaiId)
    {
        var territorio = TerritorioRepository.RecuperarPorPaiId(territorioPaiId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IEnumerable<Territorio> RecuperarPorNivelId(int nivelId)
    {
        var territorio = TerritorioRepository.RecuperarPorNivelId(nivelId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public TerritorioHierarquia RecuperarHierarquia(int territoryId)
    {
        var territorio = TerritorioRepository.RecuperarHierarquia(territoryId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }
}