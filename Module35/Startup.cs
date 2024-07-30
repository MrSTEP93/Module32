using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module35.Go.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module35.Go
{
    public class Startup
    {
        private static IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _env = env;

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            /*
            //��������� ��������� ��� ����������� �������� � �������������� ������ Use.
            app.Use(async (context, next) =>
            {
                // ��� ����������� ������ � ������� ���������� �������� ������� HttpContext
                Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
                await next.Invoke();
            });
            */

            // ���������� ����������� � �������������� �� �������������� ����
            app.UseMiddleware<ConsoleLoggingMiddleware>();
            app.UseMiddleware<FileLoggingMiddleware>();
            
            //��������� ��������� � ���������� ��������� ��� ������� ��������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!");
                });
            });

            // ��� ������ �������� ����� ��������� �����������
            app.Map("/about", About);
            app.Map("/config", Config);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}! \n You has opened incorrect page =( ");
            });
        }

        /// <summary>
        ///  ���������� ��� ������� ��������
        /// </summary>
        private static void Config(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"App name: {_env.ApplicationName}. App running configuration: {_env.EnvironmentName}");
            });
        }

        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"{_env.ApplicationName} - ASP.Net Core tutorial project");
            });
        }
    }
}
