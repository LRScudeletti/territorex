using System.ComponentModel;

namespace TerritorEx.Api.Helpers.Exceptions;

// ReSharper disable UnusedAutoPropertyAccessor.Global
[Description("schema_message")]
public class Mensagem
{
    [Description("schema_message_codigo")]
    public int Codigo { get; set; }

    [Description("schema_message_descricao")]
    public string Descricao { get; set; }

    [Description("schema_message_rastro")]
    public string Rastro { get; set; }
}