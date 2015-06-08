using System.ComponentModel.DataAnnotations;
using TeamworkReporter.Types.Validations;

namespace TeamworkReporter.Models.Auth
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public class SignUpViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "The length is below the minimum.")]
        [MaxLength(50, ErrorMessage = "The length exceeds the maximum length.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "It must be at least 6 symbols.")]
        [MaxLength(25, ErrorMessage = "The length exceeds the maximum length.")]
        public string Password { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "It must be at least 6 symbols.")]
        [MaxLength(25, ErrorMessage = "The length exceeds the maximum length.")]
        public string ConfirmPassword { get; set; }
    }
}