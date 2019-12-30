using WebFileSystemCore.Configuration;
using WebFileSystemCore.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebFileSystemCore.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class WebFileSystemCoreDbContextFactory : IDesignTimeDbContextFactory<WebFileSystemCoreDbContext>
    {
        public WebFileSystemCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebFileSystemCoreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(WebFileSystemCoreConsts.ConnectionStringName)
            );

            return new WebFileSystemCoreDbContext(builder.Options);
        }
    }
}