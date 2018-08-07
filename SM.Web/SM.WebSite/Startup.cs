using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SM.Common;
using SM.WebSite.Models;

namespace SM.WebSite
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            string mysql = Configuration.GetConnectionString("MySqlConn");
            //为StartUp.cs添加属性
            //log4net
            // repository = LogManager.CreateRepository("NETCoreRepository");
            //指定配置文件
            //  XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));
            LogUtils.Info("Info信息");
            LogUtils.Debug("Debug信息");
            LogUtils.Error("Error信息");

        }

        public IConfiguration Configuration { get; }

        public static IContainer AutofacContainer;
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);//将services中的服务填充到Autofac中
            builder.RegisterModule<DependencyModule>();//新模块组件注册

            AutofacContainer = builder.Build();
            return new AutofacServiceProvider(AutofacContainer); //使用容器创建 AutofacServiceProvider

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
            app.UseMvc(router =>
            {
                router.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });
            });
            //程序停止调用函数
            appLifetime.ApplicationStopped.Register(() => { AutofacContainer.Dispose(); });

        }
    }
}
