using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;

namespace TerritorEx.Api.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IStringLocalizer<Resources> _localizer;

    public AuthorizeAttribute(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var usuario = (Usuario)context.HttpContext.Items["Usuario"];
        if (usuario == null)
            context.Result = new JsonResult(new { message = _localizer["sem_autorizacao"] }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}