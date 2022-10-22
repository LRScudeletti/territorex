using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Models;

public class AreaPreservacaoPermanente
{
    [Key]
    public int AreaId { get; set; }

    public int TerritorioId { get; set; }

    public int SicarId { get; set; }

    public string Descricao { get; set; }

    public double AreaHectare { get; set; }

    public byte[] Shape { get; set; }
}