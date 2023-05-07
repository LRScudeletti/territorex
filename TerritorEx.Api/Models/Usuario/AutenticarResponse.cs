namespace TerritorEx.Api.Models.Usuario;
public class AutenticarResponse
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}
