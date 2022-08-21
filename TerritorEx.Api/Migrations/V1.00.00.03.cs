using Microsoft.EntityFrameworkCore.Migrations;

namespace TerritorEx.Api.Migrations;

public partial class V1000003 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
           INSERT [Levels] ([LevelName],[UpdateUser],[UpdateDate])
           SELECT 'País','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Região Demográfica','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Unidade Federativa','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Mesorregião','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Microrregião','SCUDX','2022-08-09 20:31:59.867' UNION ALL
           SELECT 'Cidade','SCUDX','2022-08-09 20:31:59.867'");
    }
}
