using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models.Shop
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}