using ASP.NET_Core_Example.Example1DI;
using ASP.NET_Core_Example.Example1DI.Abstractions;
using ASP.NET_Core_Example.Example1DI.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP.NET_Core_Example
{
    public class Startup
    {
        // Регистрация сервисов в DI-контейнере сервисов
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Конфигурация конвейера HTTP запроса
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        } 
    }
}
