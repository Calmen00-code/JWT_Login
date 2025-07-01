using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.DTO
{
    public class RegistrationRequestDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
