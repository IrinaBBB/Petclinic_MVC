using System.ComponentModel.DataAnnotations;

namespace Petclinic.Models
{
    public class RecoverPasswordViewModel
    {

        [Required]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Passwords Should Match")]
        public string PasswordConfirm { get; set; }

        public string Code { get; set; }
        public string Id { get; set; }
    }
}