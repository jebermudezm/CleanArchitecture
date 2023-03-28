using Domain.Exception;
using Microsoft.Extensions.Logging;

namespace Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return;
            }

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (httpContext.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started.");
                    throw;
                }

                var logMessageException = $"Exception Not Controlled: {ex.Message}";

                if (ex.GetBaseException() is BusinessException)
                {
                    logMessageException = $"BusinessException Controled: {ex.Message}";
                }

                _logger.LogError(logMessageException, ex);

                await httpContext.HandleExceptionAsync(ex);
            }
        }
    }
}
