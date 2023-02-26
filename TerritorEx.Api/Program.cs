using TerritorEx.Api.Configurations;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

{ // Services
    builder.Services.AddControllers();
    builder.Services.Register();

    builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
    builder.Services.AddSwaggerGen(builder.Configuration);
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddRouting(x => x.LowercaseUrls = true);

    // Configura��es do banco de dados
    Connection.AddConnectionString(builder);
}

{ // Application
    var app = builder.Build();

    // S� vai executar os scripts se o ambiente for produ��o
    var dbUpSuccess = true;
    if (!app.Environment.IsDevelopment())
        dbUpSuccess = DbUpConfiguration.AtualizarBancoDados();

    SwaggerConfiguration.UseSwaggerUi(app);

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
