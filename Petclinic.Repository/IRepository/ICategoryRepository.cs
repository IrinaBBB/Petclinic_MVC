using PetClinic.DataAccess.Entities.Shop;

namespace Petclinic.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}