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
                // �쳣��ʾ�м��
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //DefaultFilesOptions defaultFilesOptions=new 

            //���Ĭ���ļ��м��
            // Ĭ�ϲ��ҵ��ļ�  index.html  index.htm  default.html     default.htm
            app.UseDefaultFiles();

            //��Ӿ�̬�ļ��м��
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
