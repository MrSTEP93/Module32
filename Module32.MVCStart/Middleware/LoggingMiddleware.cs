using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Module32.MVCStart.Models.Repositories;
using Module32.MVCStart.Models.Db;

namespace Module32.MVCStart.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingRepository _loggingRepo;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            //_loggingRepo = loggingRepository;
        }

        public async Task InvokeAsync(HttpContext context, ILoggingRepository loggingRepository)
        {
            
            Request request = new()
            {
                Id = new Guid(),
                Url = $"http://{context.Request.Host.Value + context.Request.Path}",
                Date = DateTime.Now
            };

            await loggingRepository.Log(request);
            await _next.Invoke(context);
        }
    }
}
