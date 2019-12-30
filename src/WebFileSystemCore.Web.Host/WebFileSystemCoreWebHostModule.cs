using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebFileSystemCore.Configuration;

namespace WebFileSystemCore.Web.Host
{
    [DependsOn(
    typeof(WebFileSystemCoreApplicationModule))]
    public class WebFileSystemCoreWebHostModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        public WebFileSystemCoreWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreWebHostModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore()
              .CreateControllersForAppServices(
                  typeof(WebFileSystemCoreApplicationModule).GetAssembly()
              );
        }
    }
}
