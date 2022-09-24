using TerritorEx.Api.Models.Nivel;

namespace TerritorEx.Api.Interfaces;

public interface INivel
{
    Nivel Criar(CriarNivel criarNivel);

    IEnumerable<Nivel> RecuperarTodos();

    Nivel RecuperarPorId(int territorioId);
}

