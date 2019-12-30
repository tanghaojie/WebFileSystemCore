using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebFileSystemCore.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : WebFileSystemCoreWebHostControllerBase
    {
        [HttpPost]
        public string Test()
        {
            return "Test";
        }
    }
}
