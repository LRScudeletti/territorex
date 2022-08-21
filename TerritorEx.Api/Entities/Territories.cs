using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TerritorEx.Api.Entities;

// Indexes
[Index(nameof(TerritoryParentId), IsUnique = false, Name = "IX_Territories_TerritoryParentId")]

public class Territories
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int TerritoryId { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(50)")]
    public string TerritoryName { get; set; }

    [Required]
    public int TerritoryParentId { get; set; }

    [Required]
    public int LevelId { get; set; }

    [ForeignKey("LevelId")]
    public Levels Levels { get; set; }

    [Required]
    [Column(TypeName = "DECIMAL(38,18)")]
    public double Latitude { get; set; }

    [Required]
    [Column(TypeName = "DECIMAL(38,18)")]
    public double Longitude { get; set; }

    [Required]
    public byte[] Shape { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(50)")]
    public string UpdateUser { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }
}