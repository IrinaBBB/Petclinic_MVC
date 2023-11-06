namespace Petclinic.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IBlogRepository Blog { get; }
        void Save();
    }
}
