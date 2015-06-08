using System.ComponentModel.DataAnnotations;

namespace TeamworkReporter.Models.Auth
{
    public class SignInViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Email length is below the minimum.")]
        [MaxLength(50, ErrorMessage = "Email length exceeds the maximum length.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 symbols.")]
        [MaxLength(25, ErrorMessage = "Password length exceeds the maximum length.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}