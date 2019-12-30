using Microsoft.EntityFrameworkCore;

namespace WebFileSystemCore.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<WebFileSystemCoreDbContext> dbContextOptions, 
            string connectionString
            )
        {
            dbContextOptions.UseNpgsql(connectionString);
        }
    }
}
