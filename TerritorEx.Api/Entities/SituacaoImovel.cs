using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

public class SituacaoImovel
{
    [Key]
    public int SituacaoImovelId { get; set; }

    public string Sigla { get; set; }

    public string Descricao { get; set; }

    [JsonIgnore]
    public string UsuarioAtualizacao { get; set; }

    [JsonIgnore]
    public DateTime DataAtualizacao { get; set; }
}

