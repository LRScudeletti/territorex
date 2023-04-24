using System.Text.Json.Serialization;
using TerritorEx.Api.Configurations;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

{ // Services
    var services = builder.Services; 
    
    services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    // Adicionando ao escopo
    services.Register();

    services.AddLocalization(x => { x.ResourcesPath = Path.Combine("Localize", "Resources"); });
    services.AddSwaggerGen(configuration);
    services.AddHttpContextAccessor();
    services.AddRouting(x => x.LowercaseUrls = true);

    // Configurações do banco de dados
    Connection.AddConnectionString(builder);
}

{ // Application
    var app = builder.Build();

    app.UseLocalizationMiddleware(configuration);

    // Só vai executar os scripts se o ambiente for produção
    var dbUpSuccess = true;
    //if (!app.Environment.IsDevelopment())
        dbUpSuccess = DbUpConfiguration.AtualizarBancoDados();

    app.UseStaticFiles();
    app.UseSwaggerUi();

    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();

    // Caso ocorra algum erro de script
    // a execução da api é interrompida
    if (dbUpSuccess)
        app.Run();
}
