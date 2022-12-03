using Microsoft.Extensions.Options;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Helpers.Configuration;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Localize;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

Localization.AddLocalization(services);
ScopedConfiguration.AddInterface(services);
SwaggerConfiguration.Service(services);

services.AddControllers();
services.AddRouting(x => x.LowercaseUrls = true);
services.AddEndpointsApiExplorer();

var app = builder.Build();

Connection.AddConnectionString(builder);

// Só vai executar scripts se o ambiente for produção
var dbUpSuccess = true;
if (!app.Environment.IsDevelopment())
    dbUpSuccess = DbUpConfiguration.AtualizarBancoDados();

DapperConfiguration.Configure();
SwaggerConfiguration.App(app);

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOptions != null)
    app.UseRequestLocalization(localizationOptions.Value);

app.UseMiddleware<ErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Caso ocorra algum erro de script
// a execução da api é interrompida
if (dbUpSuccess)
    app.Run();
