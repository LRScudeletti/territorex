using TerritorEx.Api.Helpers;
using TerritorEx.Api.Services;

var builder = WebApplication.CreateBuilder(args);

# region [ Services ]

var services = builder.Services;

services.AddScoped<ITerritoryService, TerritoryService>();

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
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

#endregion
