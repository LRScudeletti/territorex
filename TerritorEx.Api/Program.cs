using Dapper.Contrib.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Microsoft.OpenApi.Models;
using TerritorEx.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);
Connection.ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");

// Essa linha altera a característica do Dapper 
// de colocar 's' no nome das entidades mapeadas
SqlMapperExtensions.TableNameMapper = (type) => type.Name;

# region [ Services ]

var services = builder.Services;

AddScoped.AdicionarInterface(services);

services.AddControllers();
services.AddRouting(x => x.LowercaseUrls = true);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    // Esse código faz com que o swagger interprete os comentários dos controllers
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

#endregion

# region [ App ]

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // options.SupportedSubmitMethods();
        options.DocExpansion(DocExpansion.None);
    });
}

app.UseMiddleware<ErrorHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion
