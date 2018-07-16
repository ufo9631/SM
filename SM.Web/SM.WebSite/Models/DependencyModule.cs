﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
namespace SM.WebSite.Models
{
    public class DependencyModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("BLL")).AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(AopInterceptor)); 
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("DAL")).AsImplementedInterfaces().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(AopInterceptor));
            //注册所有"MyApp.Repository"程序集中的类
            //builder.RegisterAssemblyTypes(GetAssembly("MyApp.Repository")).AsImplementedInterfaces();
            //  base.Load(builder);
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
