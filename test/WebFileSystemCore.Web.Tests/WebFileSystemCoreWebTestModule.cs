using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFileSystemCore.Web.Startup;
namespace WebFileSystemCore.Web.Tests
{
    [DependsOn(
        typeof(WebFileSystemCoreWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class WebFileSystemCoreWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFileSystemCoreWebTestModule).GetAssembly());
        }
    }
}