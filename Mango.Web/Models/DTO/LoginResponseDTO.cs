﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
