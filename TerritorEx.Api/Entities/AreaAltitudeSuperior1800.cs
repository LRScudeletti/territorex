using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Entities;

public abstract class AreaAltitudeSuperior1800
{
    [Key]
    public int AreaId { get; set; }

    public int TerritorioId { get; set; }

    public int SicarId { get; set; }

    public string Descricao { get; set; }

    public double AreaHectare { get; set; }

    public byte[] Shape { get; set; }

    public string UsuarioAtualizacao { get; set; }

    public DateTime DataAtualizacao { get; set; }
}