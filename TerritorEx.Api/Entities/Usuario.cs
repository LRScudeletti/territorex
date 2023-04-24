
using System.Text.Json.Serialization;
using Dapper.Contrib.Extensions;

namespace TerritorEx.Api.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
