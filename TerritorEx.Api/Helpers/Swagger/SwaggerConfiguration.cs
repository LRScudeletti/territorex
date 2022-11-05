using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TerritorEx.Api.Helpers.Swagger;

public static class SwaggerConfiguration
{
    public static void Service(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "TerritorEX API",
                //Description = Resources.SwaggerDocDocumentacaoAPITerritorEx,
                //Contact = new OpenApiContact
                //{
                //    Name = "Luiz Rogério Scudeletti",
                //    Email = "rogerio.scudeletti@gmail.com",
                //    Url = new Uri("https://www.linkedin.com/in/rogerioscudeletti/")
                //},
            });

            // Esse código faz com que o swagger interprete os comentários dos controllers
            // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // options.IncludeXmlComments(xmlPath);
        });
    }

    public static void App(WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            // options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            // options.RoutePrefix = string.Empty;
            // options.SupportedSubmitMethods();
            options.DocExpansion(DocExpansion.None);
        });
    }
}