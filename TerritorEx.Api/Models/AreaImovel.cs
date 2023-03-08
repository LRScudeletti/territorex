using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Models;

public class AreaImovel
{
    [Key]
    public int AreaId { get; set; }

    public int TerritorioId { get; set; }

    public string ImovelId { get; set; }

    public int TipoImovelId { get; set; }

    public int SituacaoImovelId { get; set; }

    public string Condicao { get; set; }

    public double AreaHectare { get; set; }

    public double AreaHectareFiscal { get; set; }

    public byte[] Shape { get; set; }
}