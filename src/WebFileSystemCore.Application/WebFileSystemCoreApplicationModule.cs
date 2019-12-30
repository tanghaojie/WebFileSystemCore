using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WebFileSystemCore
{
    [DependsOn(
        typeof(WebFileSystemCoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebFileSystemCoreApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreApplicationModule).GetAssembly());
        }
    }
}