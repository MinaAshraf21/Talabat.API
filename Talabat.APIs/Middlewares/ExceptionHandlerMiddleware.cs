using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Erros;
using Talabat.Application.Exceptions;

namespace Talabat.APIs.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            try
            {
                await _next(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var path = context.Request.Path;
                    await context.Response.WriteAsJsonAsync(new ApiResponse(StatusCodes.Status404NotFound, $"the requested endpoint: ${path} was not found."), jsonOptions);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                int statusCode;
                switch (ex)
                {
                    case NotFoundException:
                        statusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        statusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var response = _env.IsDevelopment()
                    ? new ApiExceptionResponse(statusCode, ex.Message, statusCode == 500 ? ex.StackTrace!.ToString() : null)
                    : new ApiExceptionResponse(statusCode, ex.Message);


                await context.Response.WriteAsJsonAsync(response, jsonOptions);
                
            }
        }
    }
}
