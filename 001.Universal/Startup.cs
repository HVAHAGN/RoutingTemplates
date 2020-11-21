using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using System.Collections.Specialized;
using System.Net.Mime;

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

            routeBuilder.MapRoute("Home",
                async context =>
                { await context.Response.WriteAsync("Home page"); });

            routeBuilder.MapRoute("Home/Courses",
                async context =>
                {
                    StringCollection courses = new StringCollection() {"C#", "Java", "Python", "Angular" };
                    await context.Response.WriteAsync("He is the list of available courses ");
                    foreach (var course in courses)
                    {
                        await context.Response.WriteAsync($"<br>{course}</br>");
                    }
                  
                });


            routeBuilder.MapRoute("{controller}",
                async context =>
                {
                    await context.Response.WriteAsync("{controller} template used.");
                });

            routeBuilder.MapRoute("{controller}/{action}",
                async context =>
                {
                    await context.Response.WriteAsync("{controller}/{action} template used.");
                });

            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => { await context.Response.WriteAsync("{controller}/{action}/{id} template used."); });


            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default page.");
            });
        }
    }
}
