using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace TerritorEx.Api.Migrations;

public partial class V1000001 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Levels",
            columns: table => new
            {
                LevelId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LevelName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                UpdateUser = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Levels", x => x.LevelId);
            });

        migrationBuilder.CreateTable(
            name: "Territories",
            columns: table => new
            {
                TerritoryId = table.Column<int>(type: "int", nullable: false),
                TerritoryName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                TerritoryParentId = table.Column<int>(type: "int", nullable: false),
                LevelId = table.Column<int>(type: "int", nullable: false),
                Latitude = table.Column<decimal>(type: "DECIMAL(38,18)", nullable: false),
                Longitude = table.Column<decimal>(type: "DECIMAL(38,18)", nullable: false),
                Shape = table.Column<Geometry>(type: "geometry", nullable: false),
                UpdateUser = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Territories", x => x.TerritoryId);
                table.ForeignKey(
                    name: "FK_Territories_Levels_LevelId",
                    column: x => x.LevelId,
                    principalTable: "Levels",
                    principalColumn: "LevelId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Territories_LevelId",
            table: "Territories",
            column: "LevelId");

        migrationBuilder.CreateIndex(
            name: "IX_Territories_TerritoryParentId",
            table: "Territories",
            column: "TerritoryParentId");

        migrationBuilder.Sql(@"
           INSERT [Levels] ([LevelName],[UpdateUser],[UpdateDate])
           SELECT 'País','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Região Demográfica','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Unidade Federativa','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Mesorregião','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Microrregião','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Cidade','SCUDX','2022-08-09 20:31:59.867'");

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

        //var sqlFile = Path.Combine("Migrations/Scripts/20220824000946_V1.00.00.01.sql");
        //migrationBuilder.Sql(File.ReadAllText(sqlFile));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Territories");

        migrationBuilder.DropTable(
            name: "Levels");
    }
}
