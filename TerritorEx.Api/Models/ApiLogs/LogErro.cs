namespace TerritorEx.Api.Models.Log;

public class LogErro
{
    public int Id { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    public string Mensagem { get; set; }

    public string StackTrace { get; set; }
}

