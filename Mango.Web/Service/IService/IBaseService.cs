using LoginJWT.Services.AuthAPI.DTO;
using Mango.Web.Models.DTO;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO request);
    }
}
