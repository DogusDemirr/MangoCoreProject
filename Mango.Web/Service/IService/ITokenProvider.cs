namespace Mango.Web.Service.IService
{
    public interface ITokenProvider
    {
        /// <summary>
        /// SetToken
        /// </summary>
        /// <param name="token"></param>
        void SetToken(string token);

        /// <summary>
        /// GetToken
        /// </summary>
        /// <returns></returns>
        string? GetToken();

        /// <summary>
        /// ClearToken
        /// </summary>
        void ClearToken();
    }
}
