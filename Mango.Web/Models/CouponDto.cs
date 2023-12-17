namespace Mango.Web.Models
{
    public class CouponDto
    {
        /// <summary>
        /// CouponId
        /// </summary>
        public int CouponId { get; set; }

        /// <summary>
        /// CouponCode
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// DiscountAmount
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// MinAmount
        /// </summary>
        public int MinAmount { get; set; }
    }
}
