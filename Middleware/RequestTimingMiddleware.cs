using System.Diagnostics;

namespace COMP003B.SP25.FinalProject.VerissimoA.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            var stopwatch = Stopwatch.StartNew();
            stopwatch.Stop();

            var elapsedMs = stopwatch.ElapsedMilliseconds;
            var path = context.Request.Path;
            var method = context.Request.Method;

            _logger.LogInformation("Request: {Method} {Path} executed in {Elapsed} milliseconds", method, elapsedMs, path);
        }
    }
}
