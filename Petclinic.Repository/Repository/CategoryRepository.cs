//using PetClinic.DataAccess;
//using PetClinic.Models.Shop;
//using Petclinic.Repository.IRepository;

//namespace Petclinic.Repository.Repository
//{
//    public class CategoryRepository : Repository<Category>, ICategoryRepository
//    {
//        private readonly ShopDbContext _db;
//        public CategoryRepository(ShopDbContext db) : base(db)
//        {
//            _db = db;
//        }


//        public void Update(Category category)
//        {
//            _db.Update(category);
//        }
//    }
//}