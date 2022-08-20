using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerritorEx.Api.Entities;

public class TerritoryEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TerritoryId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string TerritoryName { get; set; }

    [Required]
    public int TerritoryParentId { get; set; }

    [Required]
    public int LevelId { get; set; }

    [Required]
    [Column(TypeName = "double(38,18)")]
    public double Latitude { get; set; }

    [Required]
    [Column(TypeName = "double(38,18)")]
    public double Longitude { get; set; }

    [Required]
    public byte[] Shape { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string UpdateUser { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; } = DateTime.Now;
}