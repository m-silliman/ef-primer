using System;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(HikingService.Startup))]

namespace HikingService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
#if DEBUG
            app.UseErrorPage();
#endif
            app.UseWelcomePage("/welcome");

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            JsonMediaTypeFormatter json = new JsonMediaTypeFormatter();
            json.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            config.Formatters.Add(json);
            //config.Formatters.Add(new JsonMediaTypeFormatter());
            app.UseWebApi(config);


            app.UseSwaggerUi3(typeof(Startup).Assembly, settings =>
            {

            });

        }
    }
}
