using System.Reflection;
using System.Xml.XPath;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using TerritorEx.Api.Extensions;
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
                    Title = $"TerritorEx ({l.Trim()})",
                    Version = $"v1-{l.Trim()}",
                    Description = localizer["swagger_description"],
                    Contact = new OpenApiContact
                    {
                        Name = localizer["swagger_contact_email"],
                        Url = new Uri(localizer["swagger_contact_url"]),
                        Email = localizer["swagger_contact_email"]
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
            options.DocumentTitle = "TerritorEx API";
            options.DocExpansion(DocExpansion.None);

            var listSupportedCultures = app.Configuration.GetSection("Globalization:SupportedCultures").Get<List<string>>()
                .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

            var defaultCulture = app.Configuration["Globalization:DefaultCulture"];

            if (!string.IsNullOrWhiteSpace(defaultCulture))
                listSupportedCultures.Move(x => x.ToLower().Trim() == defaultCulture.ToLower().Trim(), 0);

            foreach (var l in listSupportedCultures)
                options.SwaggerEndpoint($"/swagger/v1-{l.Trim()}/swagger.json?lang={l.Trim()}", $"territorex-{l.Trim()}");

            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;

            options.HeadContent =
                "<link rel='stylesheet' href='./css/default.css?v=" + fileVersionInfo + "'/>" +
                "<script src='./js/jquery-3.6.3.min.js?v=" + fileVersionInfo + "'></script>" +
                "<script src='./js/jquery.initialize.min.js?v=" + fileVersionInfo + "'></script>" +
                "<script src='./js/translate/translate.js?v=" + fileVersionInfo + "'></script>";

                options.RoutePrefix = string.Empty;
        });
    }
}