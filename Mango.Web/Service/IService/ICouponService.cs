using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        //ToDo: İşlemler Abstract bir sınıfta gerçekleştirilebilir.

        /// <summary>
        /// GetCouponAsync
        /// </summary>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        Task<ResponseDto> GetCouponAsync(string couponCode);

        /// <summary>
        /// GetAllCopuponsAsync
        /// </summary>
        /// <returns></returns>
        Task<ResponseDto> GetAllCouponsAsync();

        /// <summary>
        /// GetCouponByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto> GetCouponByIdAsync(int id);

        /// <summary>
        /// CreateCouponsAsync
        /// </summary>
        /// <param name="couponDto"></param>
        /// <returns></returns>
        Task<ResponseDto> CreateCouponsAsync(CouponDto couponDto);

        /// <summary>
        /// UpdateCouponsAsync
        /// </summary>
        /// <param name="couponDto"></param>
        /// <returns></returns>
        Task<ResponseDto> UpdateCouponsAsync(CouponDto couponDto);

        /// <summary>
        /// DeleteCouponsAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseDto> DeleteCouponsAsync(int id);
    }
}
