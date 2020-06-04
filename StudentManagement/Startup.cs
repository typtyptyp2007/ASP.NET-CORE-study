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

            //mvc core ֻ������ ���ĵ�MVC����
            //mvc ������������mvc core �Լ���صĵ��������õķ���ͷ���

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
            //    //������
            //    //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            //    //var configVal = _configuration["MyKey"];

            //    logger.LogInformation("MW1:��������");

            //    //await context.Response.WriteAsync("��һ���м��");
            //    //������һ���м��
            //    await next();
            //    logger.LogInformation("MW1:������Ӧ");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2:��������");

            //    await next();
            //    logger.LogInformation("MW2:������Ӧ");
            //});

            //var defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("52abp.html");

            ////���Ĭ���ļ��м��
            //app.UseDefaultFiles(defaultFilesOptions);

            ////��Ӿ�̬�ļ��м��
            //app.UseStaticFiles();

            //var fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("52abp.html");

            //app.UseFileServer(fileServerOptions);

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute(); //.net core3.1�Ѿ����ô˷���
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
            //        //throw new Exception("���������ڹܵ��з�����һЩ��������");
            //        //await context.Response.WriteAsync($"Hosting Environment:{env.EnvironmentName}");
            //        await context.Response.WriteAsync($"hello world");

            //        //logger.LogInformation("MW3:�������󣬲�������Ӧ");
            //    });
            //});
        }
    }
}
