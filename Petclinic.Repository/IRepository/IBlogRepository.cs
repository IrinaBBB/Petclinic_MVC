using System.Collections.Generic;
using System.Threading.Tasks;
using PetClinic.ViewModel.Blog;

namespace Petclinic.Repository.IRepository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<PostViewModel>> GetAllPostsAsync();
        Task<BlogMainViewModel> GetBlogMainViewModelAsync();
    }
}

