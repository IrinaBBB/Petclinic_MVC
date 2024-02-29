using Microsoft.AspNetCore.Identity;

namespace Petclinic.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Vet Vet { get; set; }
        public Owner Owner { get; set; }
    }
}

