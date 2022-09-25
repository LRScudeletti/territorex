using System.Net;
using System.Text.Json;
using TerritorEx.Api.Models.Log;

namespace TerritorEx.Api.Helpers;

public class ErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

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
                    // Custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    // Not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Unhandled error
                    _logger.LogError(exception, exception.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            if (!string.IsNullOrEmpty(exception.Message))
            {
                var result = JsonSerializer.Serialize(new { message = exception.Message });

                var erro = new LogErro
                {
                    Mensagem = exception.Message,
                    StackTrace = exception.ToString()
                };

                Utils.CriarLogErroDatabase(erro);

                await response.WriteAsync(result);
            }
        }
    }
}