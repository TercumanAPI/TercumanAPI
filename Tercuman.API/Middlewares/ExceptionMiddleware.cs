using System.Net;
using System.Text.Json;
using Tercuman.API.Models;
using Tercuman.Application.Exceptions;

namespace Tercuman.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                var statusCode = ex switch
                {
                    ValidationException => HttpStatusCode.BadRequest,
                    UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                    _ => HttpStatusCode.InternalServerError
                };

                context.Response.StatusCode = (int)statusCode;

                var payload = ApiResponse<object>.Fail(
                    _env.IsDevelopment() ? ex.Message : "Sunucu tarafında bir hata oluştu.",
                    _env.IsDevelopment() ? new[] { ex.StackTrace ?? ex.Message } : null);

                await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
            }
        }
    }
}
