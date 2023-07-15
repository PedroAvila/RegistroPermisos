using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
