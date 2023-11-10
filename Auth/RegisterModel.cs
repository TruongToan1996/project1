using System.ComponentModel.DataAnnotations;

namespace Aptech3.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Qualification { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
        public string? UserCode { get; set; }
        [Required(ErrorMessage = "UserCode is required")]
        public string? Firstname { get; set; }
        
        public string? Lastname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
