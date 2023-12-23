using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class Coupon : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
