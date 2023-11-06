using AutoMapper;
using Petclinic.DataAccess;
using PetClinic.DataAccess;
using Petclinic.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using PetClinic.DataAccess.Entities.Identity;

namespace Petclinic.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDbContext _db;
        private readonly BlogDbContext _blogDb;

        public UnitOfWork(ShopDbContext db, BlogDbContext blogDb, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _db = db;
            _blogDb = blogDb;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            Blog = new BlogRepository(_blogDb, userManager, mapper);
        }

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IBlogRepository Blog { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
            _blogDb.SaveChanges();
        }


    }
}