using System.Diagnostics;
using api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api.Common.Errors;

public class ApiProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    public ApiProblemDetailsFactory(ApiBehaviorOptions options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public override ProblemDetails CreateProblemDetails
    (
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null
    )
    {
        statusCode ??= 500;

        var pd = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        ApplyProblemDetailsDefaults(httpContext, pd, statusCode.Value);

        return pd;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails
    (
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null
    )
    {
        if (modelStateDictionary == null)
        {
            throw new ArgumentException(nameof(modelStateDictionary));
        }

        statusCode ??= 400;

        var pd = new ValidationProblemDetails(modelStateDictionary)
        {
            Detail = detail,
            Status = statusCode,
            Instance = instance,
            Type = type
        };

        if (title != null)
        {
            pd.Title = title;
        }

        ApplyProblemDetailsDefaults(httpContext, pd, statusCode.Value);

        return pd;
    }

    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var mapping))
        {
            problemDetails.Title ??= mapping.Title;
            problemDetails.Type ??= mapping.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        if (traceId == null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        var errors = httpContext?.Items[HttpContextItemKeys.ERRORS] as List<Error>;

        if (errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }
}