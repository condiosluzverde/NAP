﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Nap.Demo.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Properties.TryAdd("UserAccountRepository", new Repository.UserAccountRepository(Data.ProviderFactory.GetSimpleUserAccountProvider()));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
