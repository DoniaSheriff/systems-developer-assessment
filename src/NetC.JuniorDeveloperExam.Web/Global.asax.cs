using Microsoft.Extensions.DependencyInjection;
using NetC.JuniorDeveloperExam.Web.Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class MvcApplication : HttpApplication
    {
        private readonly IBlogPosts blogPosts;
        public MvcApplication()
        {
            this.blogPosts = new BlogPostsService();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
