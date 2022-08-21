using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Entities;

public class Levels
{
    [Key]
    public int LevelId { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(50)")]
    public string LevelName { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR(50)")]
    public string UpdateUser { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }

    // Foreign keys
    public List<Territories> Territories { get; set; }
}

