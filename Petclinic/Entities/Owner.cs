using Microsoft.Extensions.Hosting;

namespace Petclinic.Entities
{
    public class Owner : Person
    {
        public ICollection<Pet> Pets { get; } = new List<Pet>();
    }
}
