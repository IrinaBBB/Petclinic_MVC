//using System.Linq;
//using PetClinic.DataAccess;
//using PetClinic.Models.Shop;
//using Petclinic.Repository.IRepository;

//namespace Petclinic.Repository.Repository
//{
//    public class ProductRepository : Repository<Product>, IProductRepository
//    {
//        private readonly ShopDbContext _db;
//        public ProductRepository(ShopDbContext db) : base(db)
//        {
//            _db = db;
//        }

//        public void Update(Product obj)
//        {
//            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
//            if (objFromDb != null)
//            {
//                objFromDb.Name = obj.Name;
//                objFromDb.Description = obj.Description;
//                objFromDb.ListPrice = obj.ListPrice;
//                objFromDb.Price = obj.Price;
//                objFromDb.Price50 = obj.Price50;
//                objFromDb.Price100 = obj.Price100;
//                objFromDb.CategoryId = obj.CategoryId;

//                if (obj.ImageUrl != null)
//                {
//                    objFromDb.ImageUrl = obj.ImageUrl;
//                }
//            }
//        }
//    }
//}
