using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
    public class Coupon
    {
        /// <summary>
        /// CouponId
        /// </summary>
        [Key]
        public int CouponId { get; set; }

        /// <summary>
        /// CouponCode
        /// </summary>
        [Required]
        public string CouponCode { get; set; }

        /// <summary>
        /// DiscountAmount
        /// </summary>
        [Required]
        public double DiscountAmount { get; set; }

        /// <summary>
        /// MinAmount
        /// </summary>
        public int MinAmount { get; set; }
    }
}
