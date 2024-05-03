using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;
using ProjectTronic.Backend.Core.Models;

namespace ProjectTronic.Backend.WebApi;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        // access the exception and the original request path in an error handler
        var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
        {
            httpContext.Response.StatusCode = contextFeature.Error switch
            {
                FileNotFoundException => StatusCodes.Status404NotFound,
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            // _logger.LogError($"Something went wrong: ${exception.Message}");

            await httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = contextFeature.Error.Message
            }.ToString());
        }

        //return "true" to state that the execution in the pipeline is over
        return true;
    }
}