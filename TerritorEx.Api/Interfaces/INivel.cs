using TerritorEx.Api.Models.Nivel;

namespace TerritorEx.Api.Interfaces;

public interface INivel
{
    IEnumerable<Nivel> RecuperarTodos();

    Nivel RecuperarPorId(int territorioId);
}

