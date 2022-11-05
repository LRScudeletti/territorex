using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface ITerritorio
{
    IReadOnlyList<Territorio> RecuperarTodos();

    Territorio RecuperarPorId(int territorioId);

    IReadOnlyList<Territorio> RecuperarPorNome(string territorioNome);

    IReadOnlyList<Territorio> RecuperarPorTerritorioSuperiorId(int territorioSuperiorId);

    IReadOnlyList<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId);

    TerritorioHierarquia RecuperarHierarquia(int territorioId);
}

