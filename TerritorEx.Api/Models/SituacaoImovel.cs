using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models;

public class SituacaoImovel
{
    [Key]
    public int SituacaoImovelId { get; set; }

    public string Sigla { get; set; }

    public string Descricao { get; set; }
}

