using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        /// <summary>
        /// SendAsync interface
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
