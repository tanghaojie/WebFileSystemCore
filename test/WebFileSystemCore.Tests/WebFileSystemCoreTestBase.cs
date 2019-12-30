using System;
using System.Threading.Tasks;
using Abp.TestBase;
using WebFileSystemCore.EntityFrameworkCore;
using WebFileSystemCore.Tests.TestDatas;

namespace WebFileSystemCore.Tests
{
    public class WebFileSystemCoreTestBase : AbpIntegratedTestBase<WebFileSystemCoreTestModule>
    {
        public WebFileSystemCoreTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<WebFileSystemCoreDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<WebFileSystemCoreDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<WebFileSystemCoreDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebFileSystemCoreDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<WebFileSystemCoreDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<WebFileSystemCoreDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<WebFileSystemCoreDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebFileSystemCoreDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
