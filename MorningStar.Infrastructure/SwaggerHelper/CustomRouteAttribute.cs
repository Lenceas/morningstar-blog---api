﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Extensions;
using static MorningStar.Infrastructure.CustomApiVersion;

namespace MorningStar.Infrastructure
{
    /// <summary>
    /// 自定义路由特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
    {
        /// <summary>
        /// 分组名称,是来实现接口 IApiDescriptionGroupNameProvider
        /// </summary>
        public string GroupName { get; set; } = ApiVersions.v1.GetDisplayName();

        /// <summary>
        /// 自定义路由构造函数，继承基类路由
        /// </summary>
        /// <param name="actionName"></param>
        public CustomRouteAttribute(string actionName = "[action]") : base("/api/{version}/[controller]/" + actionName)
        {
        }
        /// <summary>
        /// 自定义版本+路由构造函数，继承基类路由
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="version"></param>
        public CustomRouteAttribute(ApiVersions version, string actionName = "[action]") : base($"/api/{version.ToString()}/[controller]/{actionName}")
        {
            GroupName = version.ToString();
        }
    }
}