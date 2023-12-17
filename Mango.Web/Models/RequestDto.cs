using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        /// <summary>
        /// ApiType
        /// </summary>
        public ApiType ApiType { get; set; } = ApiType.GET;

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; } 

    }
}
