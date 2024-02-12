using Serilog;
namespace server.MiddleWares
{
    public class ErrorMiddleWare
    {

        private readonly RequestDelegate _next;

        public ErrorMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"message: + {ex.Message}  source: {ex.Source}");
            }
        }
    }
}
