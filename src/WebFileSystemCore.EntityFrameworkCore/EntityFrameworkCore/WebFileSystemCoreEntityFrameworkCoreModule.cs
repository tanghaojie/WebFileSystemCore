using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WebFileSystemCore.EntityFrameworkCore
{
    [DependsOn(
        typeof(WebFileSystemCoreCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class WebFileSystemCoreEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreEntityFrameworkCoreModule).GetAssembly());
        }
    }
}