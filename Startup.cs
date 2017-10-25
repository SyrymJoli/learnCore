using System;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.IO;

namespace learnCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        public void Configure(IApplicationBuilder app)
        {
           app.UseOwin(pipeline =>
            {
                pipeline(next => SendResponseAsync);
            });
        }

        public Task SendResponseAsync(IDictionary<string, object> environment)
        {
            // получаем заголовки запроса
            var requestHeaders = (IDictionary<string, string[]>)environment["owin.RequestHeaders"];
            // получаем данные по User-Agent
            string responseText = requestHeaders["User-Agent"][0];
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseText);
            
            var responseStream = (Stream)environment["owin.ResponseBody"];
        
            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
