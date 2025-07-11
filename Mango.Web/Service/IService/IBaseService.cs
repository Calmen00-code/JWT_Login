﻿using Mango.Web.Models.DTO;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO request, bool withBearer = true);
    }
}
