﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;

namespace MorningStar.Extension
{
    /// <summary>
    /// 注册【Autofac】容器服务
    /// </summary>
    public class AutofacModuleRegister : Autofac.Module
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var cacheType = new List<Type>();

            // 注册服务层
            var assemblyServices = Assembly.Load("MorningStar.Service");
            builder.RegisterAssemblyTypes(assemblyServices)
                   .AsImplementedInterfaces()
                   .InstancePerDependency()
                   .PropertiesAutowired()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(cacheType.ToArray()); // 允许将拦截器服务的列表分配给注册。

            // 注册仓储层
            var assemblyRepositorys = Assembly.Load("MorningStar.Repository");
            builder.RegisterAssemblyTypes(assemblyRepositorys)
                   .AsImplementedInterfaces()
                   .PropertiesAutowired()
                   .InstancePerDependency();
        }
    }
}