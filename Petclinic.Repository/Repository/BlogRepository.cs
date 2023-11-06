using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Petclinic.DataAccess;
using Petclinic.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetClinic.DataAccess.Entities.Identity;
using PetClinic.ViewModel.Blog;

namespace Petclinic.Repository.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public BlogRepository(BlogDbContext db, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPostsAsync()
        {
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(await _db.Posts.ToListAsync());
            var postViewModels = posts as PostViewModel[] ?? posts.ToArray();
            foreach (var post in postViewModels)
            {
                post.Author = await _userManager.FindByIdAsync(post.AuthorId);
            }

            return postViewModels;
        }

        public async Task<BlogMainViewModel> GetBlogMainViewModelAsync()
        {
            var posts = _mapper.Map<IEnumerable<PostViewModel>>(await _db.Posts.ToListAsync());
            var postViewModels = posts as PostViewModel[] ?? posts.ToArray();
            foreach (var post in postViewModels)
            {
                post.Author = await _userManager.FindByIdAsync(post.AuthorId);
            }

            var archiveDateList = await _db.Posts
                .Select(p => p.Created)
                .Select(d => new DateTime(d.Year, d.Month, 1))
                .Distinct()
                .ToListAsync();
            var orderedDateList = archiveDateList
                .OrderByDescending(p => p.Year)
                .ThenByDescending(p => p.Month)
                .ToList();

            return new BlogMainViewModel
            {
                Posts = postViewModels.Skip(3),
                MainPost = postViewModels.FirstOrDefault(),
                FeaturedPosts = postViewModels.Skip(1).Take(2),
                ArchiveDateList = orderedDateList
            };
        }
    }
}