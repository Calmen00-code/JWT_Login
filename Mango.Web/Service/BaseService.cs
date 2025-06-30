using LoginJWT.Services.AuthAPI.DTO;
using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO?> SendAsync(RequestDTO request)
        {
            try
            {
                // client can be of any name here
                HttpClient client = _httpClientFactory.CreateClient("JWT");

                HttpRequestMessage requestMessage = new HttpRequestMessage();
                // TODO: try to change accept to something else
                requestMessage.Headers.Add("Accept", "application/json");

                requestMessage.RequestUri = new Uri(request.Url);

                // data will be null on GET, otherwise the rest of the request type will have data
                if (request.Data != null)
                {
                    requestMessage.Content = new StringContent(
                        JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }

                // determine the API type here
                switch (request.ApiType)
                {
                    case ApiType.POST:
                        requestMessage.Method = HttpMethod.Post;
                        break;

                    case ApiType.DELETE:
                        requestMessage.Method = HttpMethod.Delete;
                        break;

                    case ApiType.PUT:
                        requestMessage.Method = HttpMethod.Put;
                        break;

                    default:
                        requestMessage.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage? apiResponse = null;
                apiResponse = await client.SendAsync(requestMessage);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDTO() { IsSuccess = false, Message = "Not found" };

                    case HttpStatusCode.Forbidden:
                        return new ResponseDTO() { IsSuccess = false, Message = "Access denied" };

                    case HttpStatusCode.Unauthorized:
                        return new ResponseDTO() { IsSuccess = false, Message = "Unauthorized" };

                    case HttpStatusCode.InternalServerError:
                        return new ResponseDTO() { IsSuccess = false, Message = "Internal server error" };

                    default:
                        // successful request, decoding the response data
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDTO;
                }
            }
            catch (Exception ex)
            {
                ResponseDTO errorDto = new ResponseDTO()
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return errorDto;
            }
        
        }
    }
}
