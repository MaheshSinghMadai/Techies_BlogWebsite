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
                entity.Description = items.Description;
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
                Description = bpm.Description,
            };

            //passing BlogPost object into the CreateBlog() function
            _blogService.CreateBlog(bp);

            if (bp.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(bpm);
        }

    }
}
