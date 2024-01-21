using Mango.Web.Models;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service.IService
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;

		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.POST,
				Data = couponDto,
				Url = $"{CouponAPIBase.TrimEnd('/')}/api/coupon"
			});
		}

		public async Task<ResponseDto?> DeleteCouponsAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.DELETE,
				Url = $"{CouponAPIBase.TrimEnd('/')}/api/coupon/{id}"
			});
		}

		public async Task<ResponseDto?> GetAllCouponsAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.GET,
				Url = $"{CouponAPIBase.TrimEnd('/')}/api/coupon"
			});
		}

		public async Task<ResponseDto?> GetCouponAsync(string couponCode)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.GET,
				Url = CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
			});
		}

		public async Task<ResponseDto?> GetCouponByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.GET,
				Url = $"{CouponAPIBase.TrimEnd('/')}/api/coupon/{id}"
			});
		}

		public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.PUT,
				Data = couponDto,
				Url = CouponAPIBase + "/api/coupon"
			});
		}
	}
}
