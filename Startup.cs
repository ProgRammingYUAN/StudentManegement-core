using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }    
            
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // 异常显示中间件
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //DefaultFilesOptions defaultFilesOptions=new 

            //添加默认文件中间件
            // 默认查找的文件  index.html  index.htm  default.html     default.htm
            app.UseDefaultFiles();

            //添加静态文件中间件
            app.UseStaticFiles();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        var configVal = _configuration["MyKey"];
            //        await context.Response.WriteAsync(configVal);
            //    });
            //});

            app.Run(async context =>
            {
                await context.Response.WriteAsync("This is Second Hello World");
            });

        }
    }
}
