using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using WAES.Infra.CrossCutting.IoC;

namespace WAES.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Clearing all support formats and adding support for json ( http://www.json.org/ ) and bson ( http://bsonspec.org/ ) media types
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new BsonMediaTypeFormatter());

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Making IoC happen, calling the Ninject resolver class to instantiate all mapping items.
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(new Container().GetModule());

        }
    }
}
