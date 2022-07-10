using PetClinic.DataAccess;
using Petclinic.Repository.IRepository;

namespace Petclinic.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _db;

        public UnitOfWork(ShopDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}