using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Optimization;
using System.Web.Routing;

namespace FPS.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(cfg => {
                //cfg.MapHttpAttributeRoutes();
                cfg.Formatters.Clear();
                cfg.Formatters.Add(new BrowserJsonFormatter());
            });
            //JsonFormatter();
            Service.Infrastructure.AutomapperConfigurator.Configure();
        }

        public void JsonFormatter()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }

    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        //  Since most browser defaults do not include an "accept type" specifying json, this provides a work around
        //  Default to json over XML - any app that wants XML can ask specifically for it  ;)
        public BrowserJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SerializerSettings.Formatting = Formatting.Indented;
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Convert all dates to UTC
            SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }

        //  Change the return type to json, as most browsers will format correctly with type as text/html
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}
