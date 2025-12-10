using ContactManager.Base.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ContactManager.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is KnownException knownException && TryGetResult(exception, out var result))
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = knownException.StatusCode;
            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(result),
                cancellationToken
            );

            return true;
        }

        return false;
    }

    public static bool TryGetResult(Exception exception, [NotNullWhen(true)] out Result? result)
    {
        if (exception is KnownException knownException)
        {
            result = Result.Failure(new Error(knownException.Code, knownException.Message, knownException.StatusCode));
            return true;
        }

        result = null;
        return false;
    }
}

public abstract class KnownException : Exception
{
    public abstract int StatusCode { get; }

    public abstract bool IsMessageSensitive { get; }

    public virtual string Code => GetType().Name.Replace("Exception", string.Empty);

    public KnownException(string message)
        : base(message)
    {
    }

    public KnownException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}