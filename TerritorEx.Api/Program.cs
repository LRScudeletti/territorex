using Dapper.Contrib.Extensions;
using TerritorEx.Api.Helpers;

var builder = WebApplication.CreateBuilder(args);

Utils.ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");

// Essa linha altera a característica do Dapper 
// de colocar 's' no nome das entidades mapeadas
SqlMapperExtensions.TableNameMapper = (type) => type.Name;

# region [ Services ]

var services = builder.Services;

AddScoped.AdicionarInterface(services);

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
