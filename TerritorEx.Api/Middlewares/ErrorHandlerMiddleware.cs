﻿using System.Net;
using System.Text.Json;
using TerritorEx.Api.Enums;
using TerritorEx.Api.Helpers;
using TerritorEx.Api.Helpers.Exceptions;

namespace TerritorEx.Api.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
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
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Erro não tratado
                    logger.LogError(exception, message: exception.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new Mensagem
            {
                Codigo = response.StatusCode,
                Descricao = exception.Message,
                Rastro = exception.StackTrace
            });

            Utils.CriarLog(TipoLogEnum.Error, exception.ToString(), false);
            await response.WriteAsync(result);
        }
    }
}