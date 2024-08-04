using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Module35.Go.Middlewares
{
    public class FileLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Logger logger;

        public FileLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            logger = new(Environment.CurrentDirectory + "\\logs\\", "RequestLog.txt", true, false);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string record = $"New request to http://{context.Request.Host.Value + context.Request.Path}";
            logger.Log(record);

            await _next.Invoke(context);
        }
    }
}
