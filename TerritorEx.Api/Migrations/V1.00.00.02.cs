using Microsoft.EntityFrameworkCore.Migrations;

namespace TerritorEx.Api.Migrations;

public partial class V1000002 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
           CREATE VIEW [dbo].[ViewTerritoryHierarchy] AS
           SELECT CIT.TerritoryId AS CityId, CIT.TerritoryName AS City,
                  MIC.TerritoryId AS MicroregionId, MIC.TerritoryName AS Microregion,
                  MES.TerritoryId AS MesoregionId, MES.TerritoryName AS Mesoregion,
                  FEU.TerritoryId AS FederativeUnitId, FEU.TerritoryName AS FederativeUnit,
                  REG.TerritoryId AS RegionId, REG.TerritoryName AS Region,
                  FED.TerritoryId AS FederationId, FED.TerritoryName AS Federation
             FROM Territories CIT INNER JOIN
                  Territories MIC ON MIC.TerritoryId = CIT.TerritoryParentId INNER JOIN
                  Territories MES ON MES.TerritoryId = MIC.TerritoryParentId INNER JOIN
                  Territories FEU ON FEU.TerritoryId = MES.TerritoryParentId INNER JOIN
                  Territories REG ON REG.TerritoryId = FEU.TerritoryParentId INNER JOIN
                  Territories FED ON FED.TerritoryId = REG.TerritoryParentId
            WHERE CIT.LevelId = 6;");
    }
}