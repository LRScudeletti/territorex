using System.Reflection;
using System.Xml.XPath;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using TerritorEx.Api.Extensions;
using TerritorEx.Api.Extensions.Swagger;
using TerritorEx.Api.Localize;

namespace TerritorEx.Api.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerGen(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();

            var listSupportedCultures = configuration.GetSection("Globalization:SupportedCultures").Get<List<string>>()
                .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

            var localizer = services.BuildServiceProvider().GetService<IStringLocalizer<Resources>>();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            foreach (var l in listSupportedCultures)
            {
                Thread.CurrentThread.SetCulture(l);

                options.SwaggerDoc($"v1-{l.Trim()}", new OpenApiInfo
                {
                    Title = $"Swagger ({l.Trim()})",
                    Version = $"v1-{l.Trim()}",
                    Description = localizer["swagger_description"],
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Rogério Scudeletti",
                        Url = new Uri("https://www.linkedin.com/in/rogerioscudeletti/")
                    }
                });
            }

            var xmlDoc = new XPathDocument(xmlPath);
            options.ParameterFilter<XmlCommentsParameterFilter>(xmlDoc);
            options.RequestBodyFilter<XmlCommentsRequestBodyFilter>(xmlDoc);
            options.OperationFilter<XmlCommentsOperationFilter>(xmlDoc);

            options.IncludeXmlComments(xmlPath);
            options.OperationFilter<CustomOperationFilter>();
            options.SchemaFilter<CustomSchemaFilter>();
        });
    }

    public static void UseSwaggerUi(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);

            var listSupportedCultures = app.Configuration.GetSection("Globalization:SupportedCultures").Get<List<string>>()
                .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

            var defaultCulture = app.Configuration["Globalization:DefaultCulture"];

            if (!string.IsNullOrWhiteSpace(defaultCulture))
                listSupportedCultures.Move(x => x.ToLower().Trim() == defaultCulture.ToLower().Trim(), 0);

            foreach (var l in listSupportedCultures)
                options.SwaggerEndpoint($"/swagger/v1-{l.Trim()}/swagger.json?lang={l.Trim()}", $"swagger-{l.Trim()}");

            options.HeadContent =
                "<script src='./scripts/jquery-3.6.3.min.js'></script>" +
                "<script src='./scripts/jquery.initialize.min.js'></script>" +
                "<script src='./scripts/translate/translate.js'></script>";

            options.RoutePrefix = string.Empty;
        });
    }
}