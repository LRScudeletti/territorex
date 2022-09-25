namespace TerritorEx.Api.Models.Log;

public class Erro
{
    public int Id { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    public string Tipo { get; set; }

    public int Numero { get; set; }

    public string Codigo { get; set; }

    public string Mensagem { get; set; }

    public string Servidor { get; set; }

    public string Source { get; set; }

    public string Target { get; set; }

    public string StackTrace { get; set; }
}

