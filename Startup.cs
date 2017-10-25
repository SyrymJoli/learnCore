using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace learnCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            int x = 5;
            int y = 8;
            int z = 0;
            app.Use(async (context, next) =>
            {
                z = x * y;
                await next.Invoke();
            });
        
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"x * y = {z}");
            });
        }
    }
}
