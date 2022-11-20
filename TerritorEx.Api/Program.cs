using Microsoft.Extensions.Options;
using TerritorEx.Api.Helpers.Configuration;
using TerritorEx.Api.Helpers.Exceptions;
using TerritorEx.Api.Localize;

var builder = WebApplication.CreateBuilder(args);

DapperConfiguration.ConnectionString(builder);

var services = builder.Services;

Localization.AdicionarLocalization(services);

ScopedConfiguration.AdicionarInterface(services);

services.AddControllers();
services.AddRouting(x => x.LowercaseUrls = true);
services.AddEndpointsApiExplorer();

SwaggerConfiguration.Service(services);

var app = builder.Build();

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOptions != null) 
    app.UseRequestLocalization(localizationOptions.Value);

SwaggerConfiguration.App(app);

app.UseMiddleware<ErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();