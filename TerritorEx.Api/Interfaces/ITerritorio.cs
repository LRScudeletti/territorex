using TerritorEx.Api.Models.Territorio;

namespace TerritorEx.Api.Interfaces;

public interface ITerritorio
{
    IReadOnlyList<Territorio> RecuperarTodos();

    Territorio RecuperarPorId(int territorioId);

    IReadOnlyList<Territorio> RecuperarPorNome(string territorioNome);

    IReadOnlyList<Territorio> RecuperarPorPaiId(int territorioPaiId);

    IReadOnlyList<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId);

    TerritorioHierarquia RecuperarHierarquia(int territorioId);
}

