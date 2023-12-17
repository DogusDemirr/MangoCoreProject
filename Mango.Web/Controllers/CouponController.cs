using Microsoft.AspNetCore.Mvc;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        //ToDo : Umut ICouponService çağırılarak CouponIndex Metodu oluşturulmalı
        public IActionResult Index()
        {
            return View();
        }
    }
}
