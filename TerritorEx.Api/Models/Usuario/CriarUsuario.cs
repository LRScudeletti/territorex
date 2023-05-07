using System.ComponentModel.DataAnnotations;

namespace TerritorEx.Api.Models.Usuario
{
    public class CriarUsuario
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string UsuarioAtualizacao { get; set; }

        [Required]
        public DateTime DataAtualizacao { get; set; }
    }
}
