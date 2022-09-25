using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TerritorEx.Api.Models.Nivel;

public class CriarNivel
{
    [Required(ErrorMessageResourceName = "NomeNivelObrigatorio",
        ErrorMessageResourceType = typeof(Properties.Resources))]
    public string LevelNome { get; set; }

    [JsonIgnore]
    public string UsuarioAtualizacao { get; set; } = "ScudX";

    [JsonIgnore]
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
}

