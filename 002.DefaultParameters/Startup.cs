﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace _002.DefaultParameters
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

            routeBuilder.MapRoute("Test/{action}/{id}",
                async context =>
                {
                    await context.Response.WriteAsync("Test/{action}/{id} template used.");
                });

            routeBuilder.MapRoute("{controller=Courses}/{action=GetCourses}/{id?}",
               async context =>
               {
                   await context.Response.WriteAsync("Couses/GetCouses template is used");
               });

            routeBuilder.MapRoute("{controller=Home}/{action}/{id}",
                async context =>
                {
                    await context.Response.WriteAsync("{controller}/{action}/{id} template used.");
                });

           

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Default page.");
            });
        }
    }
}
