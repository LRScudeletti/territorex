using TerritorEx.Api.Helpers;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Services;

var builder = WebApplication.CreateBuilder(args);
Utils.ConnectionString = builder.Configuration.GetConnectionString("ApiDatabase");

# region [ Services ]

var services = builder.Services;

services.AddScoped<ITerritory, TerritoryService>();
services.AddScoped<ILevel, LevelService>();

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
