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
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                // установка обработчика ошибки
                app.UseExceptionHandler("/Home/Error");
            }
            // установка обработчика статических файлов
            app.UseStaticFiles();
            // установка аунтификации юзера на основе куки
            app.UseAuthentication();
            // установка компонентов MVC для обработки запроса 
            app.UseMvc(routes => 
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });            


            // обработка запроса - получаем контекст запроса в виде объекта context
            app.Run(async (context) =>
            {
                // отправка ответа в виде строки "Hello World!"
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
