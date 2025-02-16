
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using Serilog;

namespace PaySky.Presentation.Web.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        public async Task Invoke(HttpContext context)
        {

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null)
                return;
            if (exception != null)
            {
                // Log the error
                var errorLog = new
                {
                    Message = exception.Message,
                    StackTrace = exception.StackTrace,
                    Timestamp = DateTime.Now
                };

                var json = JsonSerializer.Serialize(errorLog);
                Log.Logger.Error(json);

                // Set the response status code to 500 (Internal Server Error)
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Return a simple error response
                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An error occurred while processing your request,try again Later :("
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
    }
}
