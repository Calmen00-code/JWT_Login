using Microsoft.AspNetCore.Identity;

namespace LoginJWT.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
