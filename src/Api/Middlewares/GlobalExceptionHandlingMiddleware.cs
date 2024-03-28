
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace RoadToApi.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) =>
        _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ProblemDetails pd = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "Server error",
                Title = "Server error",
                Detail = "Ha ocurrido un error de servidor. Contacta al administrador y reportaselo."
            };

            string json = JsonSerializer.Serialize(pd);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(json);
        }
    }
}