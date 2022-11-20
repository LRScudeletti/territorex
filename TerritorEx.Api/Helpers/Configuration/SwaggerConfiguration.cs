using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TerritorEx.Api.Helpers.Configuration;

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
                Description = "Documentação da API do sistema TerritorEx - Sistema de Exploração do Território Rural Brasileiro.",
                Contact = new OpenApiContact
                {
                    Name = "Luiz Rogério Scudeletti",
                    Email = "rogerio.scudeletti@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/rogerioscudeletti/")
                },
            });
        });
    }

    public static void App(WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            // options.SupportedSubmitMethods();
            options.DocExpansion(DocExpansion.None);
        });
    }
}