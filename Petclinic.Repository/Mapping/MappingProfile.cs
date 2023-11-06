using AutoMapper;
using PetClinic.DataAccess.Entities.Blog;
using PetClinic.ViewModel.Blog;

namespace Petclinic.Repository.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Post //
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
        }
    }
}
