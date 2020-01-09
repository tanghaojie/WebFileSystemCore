using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFileSystemCore.Web.Startup.JTConfigurerExtensions
{
    public static class DirectoryBrowser
    {
        public static void JTAddDirectoryBrowser(this IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }
        public static void JTUseDirectoryBrowser(this IApplicationBuilder app, DirectoryBrowserOptions options)
        {
            app.UseDirectoryBrowser(options);
        }
    }
}
