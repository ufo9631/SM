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
            //ΪStartUp.cs�������
            //log4net
            // repository = LogManager.CreateRepository("NETCoreRepository");
            //ָ�������ļ�
            //  XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));
            LogUtils.Info("Info��Ϣ");
            LogUtils.Debug("Debug��Ϣ");
            LogUtils.Error("Error��Ϣ");

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
            builder.Populate(services);//��services�еķ�����䵽Autofac��
            builder.RegisterModule<DependencyModule>();//��ģ�����ע��

            AutofacContainer = builder.Build();
            return new AutofacServiceProvider(AutofacContainer); //ʹ���������� AutofacServiceProvider

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
            //����ֹͣ���ú���
            appLifetime.ApplicationStopped.Register(() => { AutofacContainer.Dispose(); });

        }
    }
}
