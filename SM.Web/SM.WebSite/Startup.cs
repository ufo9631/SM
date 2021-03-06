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
        }

        public IConfiguration Configuration { get; set; }

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

            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = configBuilder.Build();
            services.AddSingleton<IConfiguration>(Configuration);//配置IConfiguration的依赖

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
