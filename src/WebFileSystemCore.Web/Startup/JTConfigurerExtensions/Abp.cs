using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFileSystemCore.EntityFrameworkCore;

namespace WebFileSystemCore.Web.Startup.JTConfigurerExtensions
{
    public static class Abp
    {
        public static IServiceProvider JTAddAbp(this IServiceCollection services)
        {
            return services.AddAbp<WebFileSystemCoreWebModule>(options =>
            {
                //options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                //    f => f.UseAbpLog4Net().WithConfig("Conf/log4net.config")
                //);
            });
        }

        public static void JTAddAbpDbContext(this IServiceCollection services)
        {
            services.AddAbpDbContext<WebFileSystemCoreDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });
        }

        public static void JTUseAbp(IApplicationBuilder app)
        {
            app.UseAbp();
        }
    }
}
