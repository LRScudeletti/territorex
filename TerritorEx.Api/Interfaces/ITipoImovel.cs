using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface ITipoImovel
{
    IReadOnlyList<TipoImovel> RecuperarTodos();

    TipoImovel RecuperarPorId(int tipoImovelId);
}

