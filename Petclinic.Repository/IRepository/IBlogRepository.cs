using PetClinic.Models.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Petclinic.Repository.IRepository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<PostViewModel>> GetAllPostsAsync();
        Task<BlogMainViewModel> GetBlogMainViewModelAsync();
    }
}

