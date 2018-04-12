using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace inspirobot
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                string inspirobotUrl = "http://inspirobot.me/api?generate=true";
    
                string resultContent;

                using(var client = new HttpClient())
                {
                    var result = await client.GetAsync(inspirobotUrl);

                    resultContent = await result.Content.ReadAsStringAsync();
                }

                context.Response.Redirect(resultContent);
            });
        }
    }
}
