using Entities.Models;
using Infrastructure;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IGenericRepository<BlogPost> _blogRepo;
        public BlogService(IGenericRepository<BlogPost> blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public IEnumerable<BlogPost> GetAllBlogs()
        {
            return _blogRepo.GetAll();
        }

        public BlogPost GetBlogById(int id)
        {
            return _blogRepo.GetById(id);
        }

        public void CreateBlog(BlogPost blogPost)
        {
            _blogRepo.Create(blogPost);
        }
        public void RemoveBlog(int id)
        {
            BlogPost blogPost = GetBlogById(id);
            _blogRepo.Delete(blogPost);
            _blogRepo.SaveChanges();
        }

        public void UpdateBlog(BlogPost blogPost)
        {
            _blogRepo.Update(blogPost);
        }
    }
}