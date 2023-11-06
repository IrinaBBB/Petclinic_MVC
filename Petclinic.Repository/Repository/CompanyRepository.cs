//using PetClinic.DataAccess;
//using PetClinic.Models.Shop;
//using Petclinic.Repository.IRepository;

//namespace Petclinic.Repository.Repository
//{
//    public class CompanyRepository : Repository<Company>, ICompanyRepository
//    {
//        private readonly ShopDbContext _db;
//        public CompanyRepository(ShopDbContext db) : base(db)
//        {
//            _db = db;
//        }


//        public void Update(Company company)
//        {
//            _db.Companies.Update(company);
//        }
//    }
//}