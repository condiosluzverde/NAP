using System;
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

            // For the demo, explicitly get the simple UserAccount repo, this repo is not async due to no calls to db.
            // The Register() method here is making a decision to inject the dependency on the SimpleUserAccountProvider as the UserAccount repository impl.
            config.Properties.TryAdd("UserAccountRepository", new Repository.UserAccountRepository(Data.ProviderFactory.GetSimpleUserAccountProvider()));

            config.EnableCors();

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
