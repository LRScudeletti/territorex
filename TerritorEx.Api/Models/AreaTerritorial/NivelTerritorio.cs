using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models.AreaTerritorial;

public class NivelTerritorio
{
    [Key]
    public int NivelTerritorioId { get; set; }

    public string Sigla { get; set; }

    public string Descricao { get; set; }
}

