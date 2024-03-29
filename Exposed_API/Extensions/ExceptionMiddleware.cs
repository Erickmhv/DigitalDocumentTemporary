﻿using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Optional.Unsafe;

namespace Exposed_API.Extensions
{
    /// <summary>
    /// Manage all execption emitted by system.
    /// </summary>
    internal static class ExceptionMiddlewareExtensions
    {
        private const string DefaultErrorMessage = "Error procesando su petición, contacte al administrador.";
        private const string ContentType = "application/json";

        /// <summary>
        /// Configure the handler exepction
        /// </summary>
        /// <param name="app">An instance of <see cref="IApplicationBuilder"/></param>
        internal static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = ContentType;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature == null)
                    {
                        await BuildResponse(context, (int)HttpStatusCode.InternalServerError,
                            DefaultErrorMessage).ConfigureAwait(false);
                        return;
                    }

                    (int statusCode, string message) = contextFeature.Error switch
                    {
                        OptionValueMissingException valueMissingException => (400, valueMissingException.Message),
                        ArgumentOutOfRangeException argumentOutOfRangeException => (400, argumentOutOfRangeException.Message),
                        ArgumentException argumentException => (400, argumentException.Message),
                        InvalidOperationException invalidOperationException => (400, invalidOperationException.Message),
                        FormatException formatException => (400, formatException.Message),
                        _ => (500, DefaultErrorMessage)
                    };

                    await BuildResponse(context, statusCode, message + contextFeature.Error?.InnerException ?? "").ConfigureAwait(false);
                });
            });
        }

        private static async Task BuildResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(new { Message = message }).ConfigureAwait(false);
        }
    }
}
