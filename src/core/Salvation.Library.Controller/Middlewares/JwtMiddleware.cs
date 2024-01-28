using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authorization;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Jwt.Enums;
using Salvation.Library.Models.Cache;

namespace Salvation.Library.Controller.Middlewares;

/// <summary>
/// JwtMiddleware
/// </summary>
public class JwtMiddleware
{
    /// <summary>
    /// RequestDelegate
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// IJwtProvider
    /// </summary>
    private readonly IJwtProvider _jwtProvider;

    /// <summary>
    /// ICookieProvider
    /// </summary>
    private readonly ICookieProvider _cookieProvider;

    /// <summary>
    /// IMemCacheProvider
    /// </summary>
    private readonly IMemCacheProvider _memCacheProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public JwtMiddleware(
        RequestDelegate next,
        IJwtProvider jwtProvider,
        ICookieProvider cookieProvider,
        IMemCacheProvider memCacheProvider)
    {
        _next = next;
        _jwtProvider = jwtProvider;
        _cookieProvider = cookieProvider;
        _memCacheProvider = memCacheProvider;
    }

    /// <summary>
    /// InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

        // Kiểm tra xem có phải là ActionEndpoint không
        if (endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>() is ControllerActionDescriptor actionDescriptor)
        {
            // Kiểm tra xem action có được gán AllowAnonymousAttribute không
            var allowAnonymousAttribute = actionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                .OfType<AllowAnonymousAttribute>()
                .FirstOrDefault();

            if (allowAnonymousAttribute != null)
            {
                context.Request.Headers.TryGetValue("Authorization", out var authorizationToken);
                var tokenString = Convert.ToString(authorizationToken);

                if (string.IsNullOrEmpty(tokenString))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorized!");
                    return;
                }

                tokenString = tokenString.Replace("Bearer ", "");
                var validatorTokenString = _jwtProvider.ValidateJwt(tokenString, JwtType.AccessToken);

                if (!validatorTokenString)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorized!");
                    return;
                }
                else
                {
                    var payload = _jwtProvider.DecodeJwtToPayload(tokenString, JwtType.AccessToken);

                    if (payload != null)
                    {
                        var userId = payload.AccountId;
                        var cache = _memCacheProvider.Get(userId);

                        if (cache != null)
                        {
                            var accountCache = (AccountCache)cache;
                            var validatorRefreshToken = _jwtProvider.ValidateJwt(accountCache.RefreshToken, JwtType.RefreshToken);

                            if (validatorRefreshToken)
                            {
                                // TODO: Get account role
                                var role = "";

                                var audiencer = "salvation-client";
                                var issuer = "salvation-auth-service";
                                var newToken = _jwtProvider.GenerateJwt(accountCache.AccountData, role, audiencer, issuer, JwtType.AccessToken);
                                
                                if (!string.IsNullOrEmpty(newToken))
                                {
                                    _cookieProvider.Set("AccessToken", newToken, 600);
                                }
                            }
                        }
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Unauthorized!");
                    return;
                }
            }
        }

        await _next(context);
    }
}

/// <summary>
/// JwtMiddlewareExtensions
/// </summary>
public static class JwtMiddlewareExtensions
{
    /// <summary>
    /// UseCustomMiddleware
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtMiddleware>();
    }
}
