using System.Threading.Tasks;
using WebFileSystemCore.Web.Controllers;
using Shouldly;
using Xunit;

namespace WebFileSystemCore.Web.Tests.Controllers
{
    public class HomeController_Tests: WebFileSystemCoreWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
