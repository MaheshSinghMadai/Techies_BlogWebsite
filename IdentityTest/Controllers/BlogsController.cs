using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using Techie.Models;

namespace Techie.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
    
        public IActionResult Index()
        {
            var blogList = _blogService.GetAllBlogs().ToList();
            var blogToView = new List<BlogPostViewModel>();

            foreach (var items in blogList)
            {
                var entity = new BlogPostViewModel();

                entity.Id = items.Id;
                entity.Title = items.Title;
                entity.PublishDate = items.PublishDate;
                entity.Content = items.Content.Substring(0, Math.Min(items.Content.Length, 100));
                blogToView.Add(entity);

            }
            return View(blogToView);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        //POST-Create 
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(BlogPostViewModel bpm)
        {
            BlogPost bp = new BlogPost()
            {
                Title = bpm.Title,
                PublishDate = DateTime.Now,
                Content = bpm.Content,
            };

            //passing BlogPost object into the CreateBlog() function
            _blogService.CreateBlog(bp);

            if (bp.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(bpm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editBlog = new BlogPostViewModel();
            BlogPost blogDetails = _blogService.GetBlogById(id);

            editBlog.Title = blogDetails.Title;
            editBlog.Content = blogDetails.Content;

            return View(editBlog);
        }

        [HttpPost]
        public IActionResult Edit(BlogPostViewModel blog)
        {
            BlogPost b = _blogService.GetBlogById(blog.Id);
            blog.Title = b.Title;
            blog.Content = b.Content;

            _blogService.UpdateBlog(b);

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            _blogService.RemoveBlog(id);
            return RedirectToAction(@"Index");
        }
    }
}
