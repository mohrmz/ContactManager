using Asp.Versioning;
using Asp.Versioning.Builder;
using Asp.Versioning.Conventions;
using ContactManager.Base.Responses;
using ContactManager.Middlewares;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Base.Extensions;

public static class HttpHandlerExt
{
    private static ApiVersionSet SetApiVersion(this IEndpointRouteBuilder app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(1, 0)
            .ReportApiVersions()
            .Build();
        return versionSet;
    }

    public static IEndpointRouteBuilder MapHttpGet<TRequest, TResponse>(this IEndpointRouteBuilder endpoints,
        string template,
        Func<MapHttpConfiguration>? config = null, double apiVersion = 1.0)
        where TRequest : IRequest<TResponse>
    {
        var endpoint = endpoints.MapGet(template,
            async (IMediator mediator, HttpContext ctx, [AsParameters] TRequest request,
                CancellationToken cancellationToken) =>
            {
                try
                {
                    var result = await mediator.Send(request, cancellationToken);
                    if (result is IResult aspResult) return aspResult;
                    return Results.Ok(CanonicalResult<TResponse>.FromValue(result, request));
                }
                catch (Exception ex)
                {
                    if (GlobalExceptionHandler.TryGetResult(ex, out var result))
                        return Results.Json(result, statusCode: result.Error?.StatusCode ?? 500);
                    throw;
                }
            })
            .Produces<CanonicalResult<TResponse>>()
            .Produces<Result>(400)
            .Produces<Result>(500)
            .WithApiVersionSet(endpoints.SetApiVersion())
            .MapToApiVersion(new ApiVersion(apiVersion));

        if (config != null) SetConfiguration(endpoint, config.Invoke());

        return endpoints;
    }

    public static IEndpointRouteBuilder MapHttpPost<TRequest, TResponse>(this IEndpointRouteBuilder endpoints,
        string template,
        Func<MapHttpConfiguration>? config = null, double apiVersion = 1.0)
        where TRequest : IRequest<TResponse>
    {
        var endpoint = endpoints.MapPost(template,
            async (IMediator mediator, HttpContext ctx, [FromBody] TRequest request,
                   IValidator<TRequest>? validator,
                   CancellationToken cancellationToken) =>
            {
                if (validator != null)
                {
                    var validationResult = await validator.ValidateAsync(request, cancellationToken);
                    if (!validationResult.IsValid)
                        return Results.BadRequest(validationResult.Errors);
                }

                try
                {
                    var result = await mediator.Send(request, cancellationToken);
                    if (result is IResult aspResult) return aspResult;
                    return Results.Ok(CanonicalResult<TResponse>.FromValue(result, request));
                }
                catch (Exception ex)
                {
                    if (GlobalExceptionHandler.TryGetResult(ex, out var result))
                        return Results.Json(result, statusCode: result.Error?.StatusCode ?? 500);
                    throw;
                }
            })
            .Produces<CanonicalResult<TResponse>>()
            .Produces<Result>(400)
            .Produces<Result>(500)
            .WithApiVersionSet(endpoints.SetApiVersion())
            .MapToApiVersion(new ApiVersion(apiVersion));

        if (config != null) SetConfiguration(endpoint, config.Invoke());
        return endpoints;
    }

    public static IEndpointRouteBuilder MapHttpPut<TRequest, TResponse>(this IEndpointRouteBuilder endpoints,
        string template,
        Func<MapHttpConfiguration>? config = null, double apiVersion = 1.0)
        where TRequest : IRequest<TResponse>
    {
        var endpoint = endpoints.MapPut(template,
            async (IMediator mediator, HttpContext ctx, [FromBody] TRequest request,
                   IValidator<TRequest>? validator,
                   CancellationToken cancellationToken) =>
            {
                if (validator != null)
                {
                    var validationResult = await validator.ValidateAsync(request, cancellationToken);
                    if (!validationResult.IsValid)
                        return Results.BadRequest(validationResult.Errors);
                }

                try
                {
                    var result = await mediator.Send(request, cancellationToken);
                    if (result is IResult aspResult) return aspResult;
                    return Results.Ok(CanonicalResult<TResponse>.FromValue(result, request));
                }
                catch (Exception ex)
                {
                    if (GlobalExceptionHandler.TryGetResult(ex, out var result))
                        return Results.Json(result, statusCode: result.Error?.StatusCode ?? 500);
                    throw;
                }
            })
            .Produces<CanonicalResult<TResponse>>()
            .Produces<Result>(400)
            .Produces<Result>(500)
            .WithApiVersionSet(endpoints.SetApiVersion())
            .MapToApiVersion(new ApiVersion(apiVersion));

        if (config != null) SetConfiguration(endpoint, config.Invoke());
        return endpoints;
    }

    public static IEndpointRouteBuilder MapHttpDelete<TRequest, TResponse>(
        this IEndpointRouteBuilder endpoints,
        string template,
        Func<MapHttpConfiguration>? config = null,
        double apiVersion = 1.0)
        where TRequest : IRequest<TResponse>
    {
        var endpoint = endpoints.MapDelete(template,
            async (IMediator mediator, HttpContext ctx, [FromBody] TRequest request,
                   IValidator<TRequest>? validator,
                   CancellationToken cancellationToken) =>
            {
                if (validator != null)
                {
                    var validationResult = await validator.ValidateAsync(request, cancellationToken);
                    if (!validationResult.IsValid)
                        return Results.BadRequest(validationResult.Errors);
                }

                try
                {
                    var result = await mediator.Send(request, cancellationToken);
                    if (result is IResult aspResult) return aspResult;
                    return Results.Ok(CanonicalResult<TResponse>.FromValue(result, request));
                }
                catch (Exception ex)
                {
                    if (GlobalExceptionHandler.TryGetResult(ex, out var result))
                        return Results.Json(result, statusCode: result.Error?.StatusCode ?? 500);
                    throw;
                }
            })
            .Produces<CanonicalResult<TResponse>>()
            .Produces<Result>(400)
            .Produces<Result>(500)
            .WithApiVersionSet(endpoints.SetApiVersion())
            .MapToApiVersion(new ApiVersion(apiVersion));

        if (config != null) SetConfiguration(endpoint, config.Invoke());
        return endpoints;
    }

    private static void SetConfiguration(IEndpointConventionBuilder endpoint, MapHttpConfiguration configuration)
    {
        if (configuration.AllowAnonymous) endpoint.AllowAnonymous();
        else endpoint.RequireAuthorization();

        if (configuration.Name != null) endpoint.WithName(configuration.Name);

        if (configuration.Description != null || configuration.Summary != null)
        {
            endpoint.WithDescription(configuration.Description ?? configuration.Summary ?? string.Empty);
            endpoint.WithSummary(configuration.Summary ?? configuration.Description ?? string.Empty);
        }

        endpoint.WithOpenApi();
    }
}
