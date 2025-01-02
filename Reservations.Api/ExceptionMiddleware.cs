using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Reservations.Api.Shared;

namespace Reservations.Api;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);  
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);  
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        logger.LogError(ex, "Uncaught exception occurred");

        var response = context.Response;
        response.ContentType = "application/json";
            
        var statusCode = ex switch
        {
            ReservationException customEx => customEx.StatusCode,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var errorResponse = new
        {
            message = ex.Message,
            details = ex.StackTrace 
        };

        response.StatusCode = statusCode;
        var jsonResponse = JsonConvert.SerializeObject(errorResponse);
        return response.WriteAsync(jsonResponse);
    }
}
