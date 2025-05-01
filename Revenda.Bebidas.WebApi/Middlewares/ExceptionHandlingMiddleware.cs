using Microsoft.AspNetCore.Mvc;
using Revenda.Bebidas.BFF.Domain.Exceptions;

namespace Revenda.Bebidas.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var requestPath = context.Request.Path;
            var requestMethod = context.Request.Method;

            if (exception is DomainException domainException)
            {
                _logger.LogInformation(
                        exception,
                        "Ocorre um erro de negócio: Erros: {@Erros}",
                        domainException.Errors.ToDictionary(x => x.Key, x => x.Message));

                var problemDetails = new ValidationProblemDetails()
                {
                    Instance = context.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Consulte a propriedade de erros para obter detalhes adicionais.",
                    Type = "Cliente",
                };

                domainException.Errors.ToList().ForEach(error =>
                    problemDetails.Errors.Add(error.Key, new string[] { error.Message }));

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            else
            {
                _logger.LogError(
                    exception,
                    $"Exceção não tratada ao processar {requestMethod} {requestPath}");


                var json = new JsonErrorResponse
                {
                    Messages = new[] { "Ops! Tente novamente mais tarde." }
                };

                if (_env.IsDevelopment())
                {
                    json.DeveloperMessage = exception.ToString();
                }

                if (context.Response.StatusCode is (>= 200 and < 300) or 0)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                await context.Response.WriteAsJsonAsync(json);
            }
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public string DeveloperMessage { get; set; }
        }
    }
}
