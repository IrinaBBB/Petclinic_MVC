using PetClinic.Models.Shop;

namespace Petclinic.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}