using System.ComponentModel.DataAnnotations;

namespace TestApp1.Models
{
    public class SignUpModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "username is required...!!")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required...!!"), EmailAddress]
        [MinLength(8)]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required...!!")]
        [MinLength(8)]
        [MaxLength(16)]
        [Compare("Confirmpassword", ErrorMessage = "Password and Confirmation Password must match..")]
        public string Password { get; set; }
        [Required(ErrorMessage = "confirm password is required...!!")]
        public string Confirmpassword { get; set; }
    }
}
