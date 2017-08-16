using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EagleAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
    .Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "APIRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Default", id = RouteParameter.Optional }
            );
        }
    }
}
