namespace TerritorEx.Api.Models.Usuario
{
    public class AtualizarUsuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
