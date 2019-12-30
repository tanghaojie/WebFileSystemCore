using Microsoft.AspNetCore.Mvc;

namespace WebFileSystemCore.Web.Controllers
{
    public class HomeController : WebFileSystemCoreControllerBase
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}