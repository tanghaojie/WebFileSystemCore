using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebFileSystemCore.Web.Controllers
{
    public class HomeController : WebFileSystemCoreControllerBase
    {
        private readonly IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public ActionResult Index()
        {
            var basePath = _config["SwaggerBasePath"];
            if (basePath == null) { basePath = ""; }
            else
            {
                if (!basePath.StartsWith("/")) { basePath = "/" + basePath; }
            }
            return Redirect($"{basePath}/swagger");
        }
    }
}