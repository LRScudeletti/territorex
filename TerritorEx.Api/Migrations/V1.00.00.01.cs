using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                Shape = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Territories");

        migrationBuilder.DropTable(
            name: "Levels");
    }
}