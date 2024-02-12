using Serilog;

namespace server.MiddleWares
{
    public class InfoMiddleWare
    {
        private readonly RequestDelegate _next;

        public InfoMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        //Invoke ולא InvokeAsync לשאות למה דווקא 
        //ומה ההבדלים
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var action = httpContext.GetRouteData().Values["action"]?.ToString();
            Log.Information($"function {action}");
            await _next(httpContext);
        }
    }
}
