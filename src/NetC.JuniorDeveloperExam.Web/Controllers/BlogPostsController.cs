using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Services;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IBlogPosts BlogPostsService;
        public BlogPostsController()
        {
            this.BlogPostsService = new BlogPostsService();
        }

        public ActionResult Index()
        {

            ViewBag.Model = BlogPostsService.GetBlogs();
            return View();
        }
        public ActionResult GetBlogPosts(int? id)
        {
            var model = BlogPostsService.GetBlog(id);
            if (model != null) ViewBag.Model = model;
            else
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Index(CommentModel commentModel)
        {
            if (BlogPostsService.AddComment(commentModel))
                return RedirectToAction("GetBlogPosts", new { id = commentModel.BlogId });
            else return View();
        }
    }
}