using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Services;

var builder = WebApplication.CreateBuilder(args);

Utils.ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");

// Essa linha altera a característica do Dapper 
// que coloca 's' no mapping das entidades.
SqlMapperExtensions.TableNameMapper = (type) => type.Name;

# region [ Services ]

var services = builder.Services;

services.AddScoped<ITerritorio, TerritorioService>();
services.AddScoped<INivel, NivelService>();

services.AddControllers();
services.AddRouting(x => x.LowercaseUrls = true);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

#endregion

# region [ App ]

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SupportedSubmitMethods();
    });
}

app.UseMiddleware<ErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion
