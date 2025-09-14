using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class LoginViewModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Password { get; set; }

        public string ReturnUrl { get; set; } = "/";

    }
}
