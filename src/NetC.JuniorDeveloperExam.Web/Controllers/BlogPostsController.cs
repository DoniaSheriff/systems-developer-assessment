using NetC.JuniorDeveloperExam.Web.Models;
using NetC.JuniorDeveloperExam.Web.Services;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IBlogPosts _blogPostsService;
        public BlogPostsController(BlogPostsService blogPostsService)
        {
            this._blogPostsService = blogPostsService;
        }

        public ActionResult Index()
        {

            ViewBag.Model = _blogPostsService.GetBlogs();
            return View();
        }
        public ActionResult GetBlogPosts(int? id)
        {
            var model = _blogPostsService.GetBlog(id);
            if (model != null) ViewBag.Model = model;
            else
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public ActionResult Index(CommentModel commentModel)
        {
            if (_blogPostsService.AddComment(commentModel))
                return RedirectToAction("GetBlogPosts", new { id = commentModel.BlogId });
            else return View();
        }
    }
}