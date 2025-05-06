using Serilog;
using System.Diagnostics;

namespace Xome.Cascade2.CamundaService.WebApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next) { 
            _next = next;
        }

        public async Task Invoke(HttpContext context) { 
            var stopWatch = Stopwatch.StartNew();
            var request = context.Request;

            Log.Information("Handling Request: {Method} {Path}", request.Method, request.Path);

            await _next(context);
            stopWatch.Stop();

            Log.Information("Completed Request: {Method} {Path} in {ElapsedMilliseconds} ms", request.Method, request.Path, 
                stopWatch.ElapsedMilliseconds);
        }
    }
}
