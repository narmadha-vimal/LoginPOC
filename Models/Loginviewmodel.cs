using System.ComponentModel.DataAnnotations;

namespace LoginPOC.Models
{
    public class Loginviewmodel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsLoginFailed { get; set; }
    }
}
