using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.IO;
using Microsoft.Owin.Extensions;

namespace Angular2OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(CustomMiddleware));
            app.UseStaticFiles();
            app.UseStageMarker(PipelineStage.MapHandler);

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);

            var physicalFileSystem = new PhysicalFileSystem(@"./www");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[]
            {
                "index.html"
            };

            app.UseFileServer(options);
        }
    }
}