namespace DependencyInjectionExample.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate,ILogger<ExceptionMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.Something went wrong");
                //context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");


                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new
                {
                    StatusCode = 500,
                    message = "Internal Server Error.",
                    Details = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
