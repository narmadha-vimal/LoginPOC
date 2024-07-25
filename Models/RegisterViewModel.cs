using System.ComponentModel.DataAnnotations;

namespace LoginPOC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        public int Id {  get; set; }
    }
}
