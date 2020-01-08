using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebFileSystemCore.Entities;

namespace WebFileSystemCore.EntityFrameworkCore
{
    public class WebFileSystemCoreDbContext : AbpDbContext
    {
        public DbSet<File> Files { get; set; }
        public WebFileSystemCoreDbContext(DbContextOptions<WebFileSystemCoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("WebFileSystemCore");
        }
    }
}
