using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SAOnlineMart.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [Column("userName")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Column("userEmail")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Column("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column("userPassword")]
        public string Password { get; set; } = string.Empty;
    }
}

