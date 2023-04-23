using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities;

[Owned]
public class RefreshToken
{
    [Key]
    [JsonIgnore]
    public int UsuarioId { get; set; }

    public string Token { get; set; }

    public string IpCriacao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataExpiracao { get; set; }

    public string IpRevogacao { get; set; }

    public string MotivoRevogacao { get; set; }

    public DateTime? DataRevogacao { get; set; }

    public string NovoToken { get; set; }

    public bool Expirado => DateTime.UtcNow >= DataExpiracao;

    public bool Revogado => DataRevogacao != null;

    public bool Ativo => !Revogado && !Expirado;
}