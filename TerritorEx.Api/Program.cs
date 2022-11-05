using TerritorEx.Api.Dapper;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Helpers.Error;
using TerritorEx.Api.Swagger;

var builder = WebApplication.CreateBuilder(args);

DapperConfiguration.ConnectionString(builder);

var services = builder.Services;

AddScoped.AdicionarInterface(services);

services.AddControllers();
services.AddRouting(x => x.LowercaseUrls = true);
services.AddEndpointsApiExplorer();

SwaggerConfiguration.Service(services);

var app = builder.Build();

SwaggerConfiguration.App(app);

app.UseMiddleware<ErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();