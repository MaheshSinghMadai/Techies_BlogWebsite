using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBlogService
    {
        IEnumerable<BlogPost> GetAllBlogs();
        BlogPost GetBlogById(int id);
        void CreateBlog(BlogPost blogPost);
        void RemoveBlog(int id);
        void UpdateBlog(BlogPost blogPost);

    }
}
