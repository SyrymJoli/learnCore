using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace learnCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
           loggerFactory.AddConsole();

           app.Run(async (context) => {
               // создаем объект логгера
               var logger = loggerFactory.CreateLogger("RequestInfoLogger");
               // пишем на консоль информацию 
               logger.LogInformation("Processing request: {0}", context.Request.Path);

               await context.Response.WriteAsync("Hello World!");
           });
        }
    }
}
