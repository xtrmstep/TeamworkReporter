using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamworkReporter.Models.Auth
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "Email length is below the minimum.")]
        [MaxLength(50, ErrorMessage = "Email length exceeds the maximum length.")]
        public string Email { get; set; }

    }
}