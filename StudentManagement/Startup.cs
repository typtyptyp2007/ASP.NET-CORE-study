using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.Models;

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
            services.AddMvc(options => { options.EnableEndpointRouting = false; }).AddXmlSerializerFormatters();

            services.AddSingleton<IStudentRepository, MockStudentRepository>();

            //mvc core 只包含了 核心的MVC功能
            //mvc 包含了依赖于mvc core 以及相关的第三方常用的服务和方法

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //var developerExceptionPageOptions = new DeveloperExceptionPageOptions {SourceCodeLineCount = 10};
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.Use(async (context, next) =>
            //{
            //    //进程名
            //    //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            //    //var configVal = _configuration["MyKey"];

            //    logger.LogInformation("MW1:传入请求");

            //    //await context.Response.WriteAsync("第一个中间件");
            //    //调用下一个中间件
            //    await next();
            //    logger.LogInformation("MW1:传出响应");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2:传入请求");

            //    await next();
            //    logger.LogInformation("MW2:传出响应");
            //});

            //var defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("52abp.html");

            ////添加默认文件中间件
            //app.UseDefaultFiles(defaultFilesOptions);

            ////添加静态文件中间件
            //app.UseStaticFiles();

            //var fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("52abp.html");

            //app.UseFileServer(fileServerOptions);

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute(); //.net core3.1已经弃用此方法
            //app.UseMvc();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        //throw new Exception("您的请求在管道中发生了一些错误，请检查");
            //        //await context.Response.WriteAsync($"Hosting Environment:{env.EnvironmentName}");
            //        await context.Response.WriteAsync($"hello world");

            //        //logger.LogInformation("MW3:处理请求，并生成响应");
            //    });
            //});
        }
    }
}
