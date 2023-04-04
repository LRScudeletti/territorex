using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;

namespace TerritorEx.Api.Extensions.Swagger;

internal class CustomSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.ParameterInfo != null)
        {
            var descriptionAttributes = context.ParameterInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
                schema.Description = descriptionAttribute.Description;
            }
        }

        if (context.MemberInfo != null)
        {
            var descriptionAttributes = context.MemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
                schema.Description = descriptionAttribute.Description;
            }
        }

        if (context.Type == null) return;
        {
            var descriptionAttributes = context.Type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length <= 0) return;

            var descriptionAttribute = (DescriptionAttribute)descriptionAttributes[0];
            schema.Description = descriptionAttribute.Description;
        }
    }
}