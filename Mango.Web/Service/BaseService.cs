using System.Net;
using System.Text;
using Newtonsoft.Json;
using Mango.Web.Models;
using static Mango.Web.Utility.SD;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
	/// <summary>
	/// BaseService
	/// </summary>
	public class BaseService : IBaseService
	{
		const string HTTP_STATUS_CODE_NOT_FOUND = "Not Found";
		const string HTTP_STATUS_CODE_ACCESS_DENIED = "Access Denied";
		const string HTTP_STATUS_CODE_UN_AUTHORIZED = "Unauthorized";
		const string HTTP_STATUS_CODE_INTERNAL_SERVER_ERROR = "Internal Server Error";

		private readonly IHttpClientFactory _httpClientFactory;
		public BaseService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<ResponseDto> SendAsync(RequestDto requestDto)
		{
			try
			{
				HttpClient httpClient = _httpClientFactory.CreateClient("MangoAPI");
				HttpRequestMessage message = new();
				message.Headers.Add("Accept", "application/json");

				message.RequestUri = new Uri(requestDto.Url);
				if (requestDto.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");

				}
				HttpResponseMessage? apiResponse = null;

				switch (requestDto.ApiType)
				{
					case ApiType.GET:
						message.Method = HttpMethod.Get;
						break;
					case ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						throw new NotImplementedException();
						//yine get metodu çağırılabilir.
				}
				apiResponse = await httpClient.SendAsync(message);

				switch (apiResponse.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new() { IsSuccess = false, Message = HTTP_STATUS_CODE_NOT_FOUND };
					case HttpStatusCode.Forbidden:
						return new() { IsSuccess = false, Message = HTTP_STATUS_CODE_ACCESS_DENIED };
					case HttpStatusCode.Unauthorized:
						return new() { IsSuccess = false, Message = HTTP_STATUS_CODE_UN_AUTHORIZED };
					case HttpStatusCode.InternalServerError:
						return new() { IsSuccess = false, Message = HTTP_STATUS_CODE_INTERNAL_SERVER_ERROR };
					default:
						var apiContent = await apiResponse.Content.ReadAsStringAsync();
						var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

						return apiResponseDto;
				}
			}
			catch (Exception ex)
			{
				var dto = new ResponseDto
				{
					Message = ex.Message.ToString(),
					IsSuccess = false,
				};
				return dto;
			}
		}
	}
}
