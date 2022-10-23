using System.Net;
using System.Text.Json;

namespace TerritorEx.Api.Helpers;

public class ErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (exception)
            {
                case AppException:
                    // Erro de aplicativo personalizado
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    // Não encontrado
                    response.StatusCode = (int)HttpStatusCode.NoContent;
                    break;
                default:
                    // Erro não tratado
                    _logger.LogError(exception, message: exception.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { errorMessage = exception.Message });

            Utils.CriarLogErro(exception.ToString());

            if (response.StatusCode != (int)HttpStatusCode.InternalServerError)
                await response.WriteAsync(result);
        }
    }
}