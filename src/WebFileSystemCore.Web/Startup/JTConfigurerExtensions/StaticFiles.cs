using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;

namespace WebFileSystemCore.Web.Startup.JTConfigurerExtensions
{
    public static class StaticFiles
    {
        public static void JTUseStaticFiles(this IApplicationBuilder app, JTStaticFileOptions options = null)
        {
            if (options == null)
            {
                app.UseStaticFiles();
                return;
            }
            if (options.UseDefault) { app.UseStaticFiles(); }
            app.UseStaticFiles(options);
        }
    }

    public class JTStaticFileOptions : StaticFileOptions
    {
        public JTStaticFileOptions() { }
        public JTStaticFileOptions(SharedOptions sharedOptions) : base(sharedOptions) { }
        /// <summary>
        /// Default true
        /// </summary>
        public bool UseDefault { get; set; } = true;
    }
}
