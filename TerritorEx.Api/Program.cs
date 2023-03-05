using TerritorEx.Api.Configurations;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

{ // Services
    var services = builder.Services;
    services.AddControllers();
    services.Register();

    services.AddLocalization(x => { x.ResourcesPath = @"Localize\Resources"; });
    services.AddSwaggerGen(configuration);
    services.AddHttpContextAccessor();
    services.AddRouting(x => x.LowercaseUrls = true);

    // Configura��es do banco de dados
    Connection.AddConnectionString(builder);
}

{ // Application
    var app = builder.Build();

    app.UseLocalizationMiddleware(configuration);

    // S� vai executar os scripts se o ambiente for produ��o
    var dbUpSuccess = true;
    if (!app.Environment.IsDevelopment())
        dbUpSuccess = DbUpConfiguration.AtualizarBancoDados();

    app.UseSwaggerUi();

    app.UseStaticFiles();
    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    // Caso ocorra algum erro de script
    // a execu��o da api � interrompida
    if (dbUpSuccess)
        app.Run();
}
