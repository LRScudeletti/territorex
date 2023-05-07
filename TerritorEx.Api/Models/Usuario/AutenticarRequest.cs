using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Models.Usuario;

public class AutenticarRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }
}