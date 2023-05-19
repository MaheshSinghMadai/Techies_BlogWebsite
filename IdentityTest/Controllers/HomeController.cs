using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Techie.Models;

namespace Techie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        public HomeController(IBlogService blogService)
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
                entity.Content = items.Content.Substring(0, Math.Min(items.Content.Length, 50));
                blogToView.Add(entity);

            }
            return View(blogToView);
        }

        public IActionResult BlogView(int id)
        {
            var viewBlog = new BlogPostViewModel();
            BlogPost blogDetail = _blogService.GetBlogById(id);

            viewBlog.Title = blogDetail.Title;
            viewBlog.Content = blogDetail.Content.Substring(0, Math.Min(blogDetail.Content.Length, 100));

            return View(viewBlog);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new IdentityTest.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}