using TerritorEx.Api.Models.Territorio;

namespace TerritorEx.Api.Interfaces;

public interface ITerritorio
{
    IEnumerable<Territorio> RecuperarTodos();

    Territorio RecuperarPorId(int territorioId);

    IEnumerable<Territorio> RecuperarPorNome(string territorioNome);

    IEnumerable<Territorio> RecuperarPorPaiId(int territorioPaiId);

    IEnumerable<Territorio> RecuperarPorNivelId(int nivelId);

    TerritorioHierarquia RecuperarHierarquia(int territorioId);
}

