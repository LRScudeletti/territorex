namespace TerritorEx.Api.Models.Territory;

public class TerritoryHierarchy
{
    public int TerritoryId { get; set; }

    public string TerritoryName { get; set; }

    public int MicroregionId { get; set; }

    public string MicroregionName { get; set; }

    public int MesoregionId { get; set; }

    public string MesoregionName { get; set; }

    public int FederativeUnitId { get; set; }

    public string FederativeUnitName { get; set; }

    public int RegionId { get; set; }

    public string RegionName { get; set; }

    public int FederationId { get; set; }

    public string FederationName { get; set; }
}