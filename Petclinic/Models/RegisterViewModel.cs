using System.ComponentModel.DataAnnotations;

namespace Petclinic.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Passwords Should Match")]
        public string PasswordConfirm { get; set; }
    }
}
