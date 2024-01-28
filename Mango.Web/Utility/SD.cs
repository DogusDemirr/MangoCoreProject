namespace Mango.Web.Utility
{
    public class SD
    {
        /// <summary>
        /// CouponAPIBase
        /// </summary>
        public static string CouponAPIBase { get; set; }

        /// <summary>
        /// AuthAPIBase
        /// </summary>
        public static string AuthAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
