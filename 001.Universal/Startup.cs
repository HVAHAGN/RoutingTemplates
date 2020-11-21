using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace _001.Universal
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // добавляем сервис маршрутизации
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{controller}",
                async context => {
                    await context.Response.WriteAsync("{controller} template used.");
                });

            routeBuilder.MapRoute("{controller}/{action}",
                async context => {
                    await context.Response.WriteAsync("{controller}/{action} template used.");
                });

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default page.");
            });
        }
    }
}
