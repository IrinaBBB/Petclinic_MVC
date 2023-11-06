using System;
using System.Collections.Generic;

namespace PetClinic.Models.Blog
{
    public class BlogMainViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public PostViewModel MainPost { get; set; }
        public IEnumerable<PostViewModel> FeaturedPosts { get; set; }
        public IEnumerable<DateTime> ArchiveDateList { get; set; }
    }
}
