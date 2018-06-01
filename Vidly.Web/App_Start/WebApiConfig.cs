using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Vidly.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Written to make the first letter fo all properties small. So that we have camelCase properties for Javascript.
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
