namespace TerritorEx.Api.Models.Territorio;

public class Territorio
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int PaiId { get; set; }

    public int NivelId { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public byte[] Shape { get; set; }
}