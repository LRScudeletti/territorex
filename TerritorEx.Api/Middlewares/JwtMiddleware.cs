using TerritorEx.Api.Authorization;

namespace TerritorEx.Api.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    //public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    //{
    //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    //    var usuarioId = jwtUtils.ValidateToken(token);
    //    if (usuarioId != null)
    //    {
    //        context.Items["Usuario"] = userService.GetById(usuarioId.Value);
    //    }

    //    await _next(context);
    //}
}