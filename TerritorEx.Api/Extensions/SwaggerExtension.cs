using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TerritorEx.Api.Extensions;

public class CustomOperationFilter : IOperationFilter
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer _localizer;

    public CustomOperationFilter(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IStringLocalizer<Resources> localizer)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _localizer = localizer;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var listSupportedCultures = _configuration.GetSection("Globalization:SupportedCultures").Get<List<string>>()
            .Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

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

        if (!string.IsNullOrWhiteSpace(queryLang))
            listSupportedCultures.Move(x => x.ToLower().Trim() == queryLang.Trim().ToLower(), 0);

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "accept-language",
            In = ParameterLocation.Header,
            Required = false,
            Description = _localizer["supported_languages"],

            Schema = new OpenApiSchema
            {
                Type = "string",
                Enum = listSupportedCultures.Select(value => (IOpenApiAny)new OpenApiString(value)).ToList(),
            }
        });
    }
}