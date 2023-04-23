using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Entities
{
    public class Usuario
    {
        [Key]
        public string Email { get; set; }

        public string Nome { get; set; }

        [JsonIgnore]
        public string SenhaHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        [JsonIgnore]
        public string UsuarioAtualizacao { get; set; }

        [JsonIgnore]
        public DateTime DataAtualizacao { get; set; }
    }
}
