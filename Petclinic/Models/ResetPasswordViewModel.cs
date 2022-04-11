using System.ComponentModel.DataAnnotations;

namespace Petclinic.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}