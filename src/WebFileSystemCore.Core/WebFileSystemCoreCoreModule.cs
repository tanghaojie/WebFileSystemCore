using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFileSystemCore.Configuration;

namespace WebFileSystemCore
{
    public class WebFileSystemCoreCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabled = false;
            Configuration.Localization.IsEnabled = false;
            Configuration.Authorization.IsEnabled = true;
            Configuration.MultiTenancy.IsEnabled = false;
            Configuration.Authorization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.EntityHistory.IsEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreCoreModule).GetAssembly());
        }
    }
}