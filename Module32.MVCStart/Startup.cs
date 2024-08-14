using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module32.MVCStart.Middleware;
using Module32.MVCStart.Models.Db;
using Module32.MVCStart.Models.Repositories;
using Module35.Go.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module32.MVCStart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
            services.AddControllersWithViews();

            // ����������� ������� ����������� ��� �������������� � ����� ������
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ILoggingRepository, LoggingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ConsoleLoggingMiddleware>();
            app.UseMiddleware<DBLoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

/*
 ������������! ������� 32.11.1, � ������ ��������� � ������ ��������. ������ � ��������� ��������� ����������� ��� ������ � ������������ � ��, 
�� ����� �� ���� ���������� � ���� � middleware. ����� � ������� �������� ��������� LoggingRepository � ������������ LoggingMiddleware, ���������� �� ����������� (����� 1),
��� �� � �� ����� ����� ����� 
*/
