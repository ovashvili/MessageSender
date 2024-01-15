using MessageSender.Application.Common.Middlewares;

namespace MessageSender.Api.Extensions;

public static class ExceptionHandlingMiddlewareExtension
{
    /// <summary>
    /// Extension for global exception handler
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}