using WebFileSystemCore.EntityFrameworkCore;

namespace WebFileSystemCore.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly WebFileSystemCoreDbContext _context;

        public TestDataBuilder(WebFileSystemCoreDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}