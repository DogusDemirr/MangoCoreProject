using Newtonsoft.Json;
using Mango.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mango.Web.Service.IService;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {

        private readonly ICouponService _couponService;
        
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public  async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if(response !=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
