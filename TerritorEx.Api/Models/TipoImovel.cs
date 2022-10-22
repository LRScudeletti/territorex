using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models;

public class TipoImovel
{
    [Key]
    public int TipoImovelId { get; set; }

    public string Sigla { get; set; }

    public string Descricao { get; set; }
}

