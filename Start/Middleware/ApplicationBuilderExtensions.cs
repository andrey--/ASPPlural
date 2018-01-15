using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var options = new StaticFileOptions();
            var fileProvider = new PhysicalFileProvider(path);
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
