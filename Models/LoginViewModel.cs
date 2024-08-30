using System.ComponentModel.DataAnnotations;

namespace SAOnlineMart.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
