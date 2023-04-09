using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using TerritorEx.Api.Localize;

// ReSharper disable ClassNeverInstantiated.Global
namespace TerritorEx.Api.Extensions;

internal class CustomOperationFilter : IOperationFilter
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<Resources> _localizer;

    public CustomOperationFilter(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IStringLocalizer<Resources> localizer)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _localizer = localizer;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var queryLang = _httpContextAccessor?.HttpContext!.Request.Query["lang"].FirstOrDefault();
        Thread.CurrentThread.SetCulture(queryLang);

        if (!string.IsNullOrWhiteSpace(operation.Summary))
            operation.Summary = _localizer[operation.Summary];

        if (!string.IsNullOrWhiteSpace(operation.Description))
            operation.Description = _localizer[operation.Description];

        if (operation.Responses is { Count: > 0 })
        {
            foreach (var response in operation.Responses
                         .Where(response => response.Value != null)
                         .Where(response => !string.IsNullOrWhiteSpace(response.Value.Description)))

                response.Value.Description = _localizer[response.Value.Description];
        }

        if (operation.RequestBody != null)
        {
            if (!string.IsNullOrWhiteSpace(operation.RequestBody.Description))
                operation.RequestBody.Description = _localizer[operation.RequestBody.Description];
        }

        if (operation.Parameters is { Count: > 0 })
        {
            foreach (var parameter in operation.Parameters)
            {
                if (string.IsNullOrWhiteSpace(parameter.Description)) continue;

                parameter.Description = _localizer[parameter.Description];
            }
        }

        var listSupportedCultures = _configuration.GetSection("Globalization:SupportedCultures").Get<List<string>>()
            .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

        if (!string.IsNullOrWhiteSpace(queryLang))
            listSupportedCultures.Move(x => x.ToLower().Trim() == queryLang.Trim().ToLower(), 0);

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "accept-language",
            Description = _localizer["supported_languages"],
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Enum = listSupportedCultures.Select(value => (IOpenApiAny)new OpenApiString(value)).ToList(),
            }
        });
    }
}

internal class CustomSchemaFilter : ISchemaFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<Resources> _localizer;

    public CustomSchemaFilter(IHttpContextAccessor httpContextAccessor, IStringLocalizer<Resources> localizer)
    {
        _httpContextAccessor = httpContextAccessor;
        _localizer = localizer;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var queryLang = _httpContextAccessor?.HttpContext!.Request.Query["lang"].FirstOrDefault();
        Thread.CurrentThread.SetCulture(queryLang);

        if (context.ParameterInfo != null)
        {
            var descriptionAttributes = context.ParameterInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
                schema.Description = _localizer[descriptionAttribute.Description];
            }
        }

        if (context.MemberInfo != null)
        {
            var descriptionAttributes = context.MemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                schema.Description = _localizer[((DescriptionAttribute)descriptionAttributes[0]).Description];
            }
        }

        if (context.Type == null) return;
        {
            var descriptionAttributes = context.Type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length <= 0) return;

            schema.Description = _localizer[((DescriptionAttribute)descriptionAttributes[0]).Description];
        }
    }
}