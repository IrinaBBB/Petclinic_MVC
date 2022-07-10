using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Shop
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
