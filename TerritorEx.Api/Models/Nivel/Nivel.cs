using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models.Nivel;

public class Nivel
{
    [Key]
    public int NivelId { get; set; }

    public string NivelNome { get; set; }
}

