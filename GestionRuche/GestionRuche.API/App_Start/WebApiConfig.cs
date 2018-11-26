using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GestionRuche.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //renvoyer du JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(

                //recherche "asp web api return json"
                new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}
