using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFileSystemCore.Configuration;
using WebFileSystemCore.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using WebFileSystemCore.Web.Host;

namespace WebFileSystemCore.Web.Startup
{
    [DependsOn(
        typeof(WebFileSystemCoreEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule),
        typeof(WebFileSystemCoreWebHostModule))]
    public class WebFileSystemCoreWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebFileSystemCoreWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(WebFileSystemCoreConsts.ConnectionStringName);
            Configuration.Navigation.Providers.Clear();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(WebFileSystemCoreApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WebFileSystemCoreWebModule).Assembly);
        }
    }
}