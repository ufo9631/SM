using AspectCore.Extensions.Autofac;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SM.Web.Models
{
    public class ApplicationStart
    {
        //public static void Dependency(IServiceCollection services)
        //{
        //    var builder = new ContainerBuilder();
        //    //builder.RegisterInstance(typeof(EFCoreContext)).SingleInstance();
        //   // builder.RegisterInstance(new EFCoreContext());
        //    var datadal = Assembly.Load("DAL");
        //    builder.RegisterAssemblyTypes(datadal).Where(a => a.FullName.Contains("DAL")).AsImplementedInterfaces();

        //    var databll = Assembly.Load("BLL");
        //    builder.RegisterAssemblyTypes(databll).Where(a => a.FullName.Contains("BLL")).AsImplementedInterfaces();
        //   // builder.RegisterControllers(Assembly.GetExecutingAssembly());

         
        //    // builder.RegisterInstance(new DbEntities()).As<DbEntities>();

        //    // 命名注入
        //    //  builder.Register(c => new CallLogger(Console.Out)).Named<IInterceptor>("log-calls");
        //    // 类型注入
        //    //  builder.Register(c => new CallLogger(Console.Out));//Aop类型注入

        //    //动态注入拦截器CallLogger
        //    //     builder.RegisterType<BLL.BasRolesBLL>().EnableInterfaceInterceptors().InterceptedBy(typeof(CallLogger)).As<IBLL.IBasRolesBLL>();

        //    //  builder.RegisterAssemblyTypes(datadal).Where(a => a.FullName.Contains("DAL")).EnableInterfaceInterceptors().InterceptedBy(typeof(CallLogger)).AsImplementedInterfaces();
        //    //  builder.RegisterAssemblyTypes(databll).Where(a => a.FullName.Contains("BLL")).EnableInterfaceInterceptors().InterceptedBy(typeof(CallLogger)).AsImplementedInterfaces();
        //    //   var contain = builder.Build();
        //    //DependencyResolver.SetResolver(new AutofacDependencyResolver(contain));
        //}
    }
}
